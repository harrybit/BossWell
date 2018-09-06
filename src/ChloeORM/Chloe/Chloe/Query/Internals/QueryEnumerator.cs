using Chloe.Core;
using Chloe.Mapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Chloe.Query.Internals
{
    internal static class QueryEnumeratorCreator
    {
        public static IEnumerator<T> CreateEnumerator<T>(InternalAdoSession adoSession, DbCommandFactor commandFactor)
        {
            return new QueryEnumerator<T>(adoSession, commandFactor);
        }

        internal struct QueryEnumerator<T> : IEnumerator<T>
        {
            private InternalAdoSession _adoSession;
            private DbCommandFactor _commandFactor;
            private IObjectActivator _objectActivator;

            private IDataReader _reader;

            private T _current;
            private bool _hasFinished;
            private bool _disposed;

            public QueryEnumerator(InternalAdoSession adoSession, DbCommandFactor commandFactor)
            {
                this._adoSession = adoSession;
                this._commandFactor = commandFactor;
                this._objectActivator = commandFactor.ObjectActivator;

                this._reader = null;

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
                    //TODO 执行 sql 语句，获取 DataReader
                    this._reader = this._adoSession.ExecuteReader(this._commandFactor.CommandText, this._commandFactor.Parameters, CommandType.Text);
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
        }
    }
}