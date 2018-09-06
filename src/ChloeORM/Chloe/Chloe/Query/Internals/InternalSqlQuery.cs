using Chloe.Descriptors;
using Chloe.Infrastructure;
using Chloe.Mapper;
using Chloe.Query.Mapping;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading;

namespace Chloe.Query.Internals
{
    internal class InternalSqlQuery<T> : IEnumerable<T>, IEnumerable
    {
        private DbContext _dbContext;
        private string _sql;
        private CommandType _cmdType;
        private DbParam[] _parameters;

        public InternalSqlQuery(DbContext dbContext, string sql, CommandType cmdType, DbParam[] parameters)
        {
            this._dbContext = dbContext;
            this._sql = sql;
            this._cmdType = cmdType;
            this._parameters = parameters;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueryEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private struct QueryEnumerator : IEnumerator<T>
        {
            private InternalSqlQuery<T> _internalSqlQuery;

            private IDataReader _reader;
            private IObjectActivator _objectActivator;

            private T _current;
            private bool _hasFinished;
            private bool _disposed;

            public QueryEnumerator(InternalSqlQuery<T> internalSqlQuery)
            {
                this._internalSqlQuery = internalSqlQuery;
                this._reader = null;
                this._objectActivator = null;

                this._current = default(T);
                this._hasFinished = false;
                this._disposed = false;
            }

            public T Current { get { return this._current; } }

            object IEnumerator.Current { get { return this._current; } }

            public bool MoveNext()
            {
                if (this._hasFinished || this._disposed)
                    return false;

                if (this._reader == null)
                {
                    this.Prepare();
                }

                if (this._reader.Read())
                {
                    this._current = (T)this._objectActivator.CreateInstance(this._reader);
                    return true;
                }
                else
                {
                    this._reader.Close();
                    this._current = default(T);
                    this._hasFinished = true;
                    return false;
                }
            }

            public void Dispose()
            {
                if (this._disposed)
                    return;

                if (this._reader != null)
                {
                    if (!this._reader.IsClosed)
                        this._reader.Close();
                    this._reader.Dispose();
                    this._reader = null;
                }

                if (!this._hasFinished)
                {
                    this._hasFinished = true;
                }

                this._current = default(T);
                this._disposed = true;
            }

            public void Reset()
            {
                throw new NotSupportedException();
            }

            private void Prepare()
            {
                Type type = typeof(T);

                if (type != UtilConstants.TypeOfObject && MappingTypeSystem.IsMappingType(type))
                {
                    MappingField mf = new MappingField(type, 0);
                    this._objectActivator = mf.CreateObjectActivator();
                    this._reader = this.ExecuteReader();
                    return;
                }

                this._reader = this.ExecuteReader();
                this._objectActivator = GetObjectActivator(type, this._reader);
            }

            private IDataReader ExecuteReader()
            {
                IDataReader reader = this._internalSqlQuery._dbContext.AdoSession.ExecuteReader(this._internalSqlQuery._sql, this._internalSqlQuery._parameters, this._internalSqlQuery._cmdType);
                return reader;
            }

            private static IObjectActivator GetObjectActivator(Type type, IDataReader reader)
            {
                if (type == UtilConstants.TypeOfObject || type == typeof(DapperRow))
                {
                    return new DapperRowObjectActivator();
                }

                List<CacheInfo> caches;
                if (!ObjectActivatorCache.TryGetValue(type, out caches))
                {
                    if (!Monitor.TryEnter(type))
                    {
                        return CreateObjectActivator(type, reader);
                    }

                    try
                    {
                        caches = ObjectActivatorCache.GetOrAdd(type, new List<CacheInfo>(1));
                    }
                    finally
                    {
                        Monitor.Exit(type);
                    }
                }

                CacheInfo cache = TryGetCacheInfoFromList(caches, reader);

                if (cache == null)
                {
                    lock (caches)
                    {
                        cache = TryGetCacheInfoFromList(caches, reader);
                        if (cache == null)
                        {
                            ObjectActivator activator = CreateObjectActivator(type, reader);
                            cache = new CacheInfo(activator, reader);
                            caches.Add(cache);
                        }
                    }
                }

                return cache.ObjectActivator;
            }

            private static ObjectActivator CreateObjectActivator(Type type, IDataReader reader)
            {
                ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
                if (constructor == null)
                    throw new ArgumentException(string.Format("The type of '{0}' does't define a none parameter constructor.", type.FullName));

                EntityConstructorDescriptor constructorDescriptor = EntityConstructorDescriptor.GetInstance(constructor);
                EntityMemberMapper mapper = constructorDescriptor.GetEntityMemberMapper();
                Func<IDataReader, ReaderOrdinalEnumerator, ObjectActivatorEnumerator, object> instanceCreator = constructorDescriptor.GetInstanceCreator();
                List<IValueSetter> memberSetters = PrepareValueSetters(type, reader, mapper);
                return new ObjectActivator(instanceCreator, null, null, memberSetters, null);
            }

            private static List<IValueSetter> PrepareValueSetters(Type type, IDataReader reader, EntityMemberMapper mapper)
            {
                List<IValueSetter> memberSetters = new List<IValueSetter>(reader.FieldCount);

                MemberInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);
                MemberInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetField);
                List<MemberInfo> members = new List<MemberInfo>(properties.Length + fields.Length);
                members.AddRange(properties);
                members.AddRange(fields);

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string name = reader.GetName(i);
                    var member = members.Find(a => a.Name == name);
                    if (member == null)
                    {
                        member = members.Find(a => string.Equals(a.Name, name, StringComparison.OrdinalIgnoreCase));
                        if (member == null)
                            continue;
                    }

                    IMRM mMapper = mapper.TryGetMappingMemberMapper(member);
                    if (mMapper == null)
                        continue;

                    MappingMemberBinder memberBinder = new MappingMemberBinder(mMapper, i);
                    memberSetters.Add(memberBinder);
                }

                return memberSetters;
            }

            private static CacheInfo TryGetCacheInfoFromList(List<CacheInfo> caches, IDataReader reader)
            {
                CacheInfo cache = null;
                for (int i = 0; i < caches.Count; i++)
                {
                    var item = caches[i];
                    if (item.IsTheSameFields(reader))
                    {
                        cache = item;
                        break;
                    }
                }

                return cache;
            }

            private static readonly System.Collections.Concurrent.ConcurrentDictionary<Type, List<CacheInfo>> ObjectActivatorCache = new System.Collections.Concurrent.ConcurrentDictionary<Type, List<CacheInfo>>();
        }

        public class CacheInfo
        {
            private ReaderFieldInfo[] _readerFields;
            private ObjectActivator _objectActivator;

            public CacheInfo(ObjectActivator activator, IDataReader reader)
            {
                int fieldCount = reader.FieldCount;
                var readerFields = new ReaderFieldInfo[fieldCount];

                for (int i = 0; i < fieldCount; i++)
                {
                    readerFields[i] = new ReaderFieldInfo(reader.GetName(i), reader.GetFieldType(i));
                }

                this._readerFields = readerFields;
                this._objectActivator = activator;
            }

            public ObjectActivator ObjectActivator { get { return this._objectActivator; } }

            public bool IsTheSameFields(IDataReader reader)
            {
                ReaderFieldInfo[] readerFields = this._readerFields;
                int fieldCount = reader.FieldCount;

                if (fieldCount != readerFields.Length)
                    return false;

                for (int i = 0; i < fieldCount; i++)
                {
                    ReaderFieldInfo readerField = readerFields[i];
                    if (reader.GetFieldType(i) != readerField.Type || reader.GetName(i) != readerField.Name)
                    {
                        return false;
                    }
                }

                return true;
            }

            private class ReaderFieldInfo
            {
                private string _name;
                private Type _type;

                public ReaderFieldInfo(string name, Type type)
                {
                    this._name = name;
                    this._type = type;
                }

                public string Name { get { return this._name; } }
                public Type Type { get { return this._type; } }
            }
        }
    }
}