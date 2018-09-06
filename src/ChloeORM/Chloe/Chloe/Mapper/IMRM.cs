using Chloe.Core;
using Chloe.Core.Emit;
using Chloe.Infrastructure;
using Chloe.InternalExtensions;
using System;
using System.Data;
using System.Reflection;

namespace Chloe.Mapper
{
    public interface IMRM
    {
        void Map(object instance, IDataReader reader, int ordinal);
    }

    internal static class MRMHelper
    {
        public static IMRM CreateMRM(MemberInfo member, MappingTypeInfo mappingTypeInfo)
        {
            if (mappingTypeInfo.DbValueConverter == null || member.GetMemberType().GetUnderlyingType().IsEnum /* 枚举比较特殊 */)
            {
                Type type = ClassGenerator.CreateMRMType(member);
                IMRM obj = (IMRM)type.GetConstructor(Type.EmptyTypes).Invoke(null);
                return obj;
            }
            else
            {
                return new MRM2(member, mappingTypeInfo.DbValueConverter);
            }
        }
    }

    internal class MRM : IMRM
    {
        private Action<object, IDataReader, int> _mapper;

        public MRM(MemberInfo member)
        {
            this._mapper = DelegateGenerator.CreateSetValueFromReaderDelegate(member);
        }

        public void Map(object instance, IDataReader reader, int ordinal)
        {
            this._mapper(instance, reader, ordinal);
        }
    }

    /// <summary>
    /// 通过 MappingTypeSystem.Configure() 配置了数据库转换器时，会使用该 MRM。
    /// </summary>
    internal class MRM2 : IMRM
    {
        private Action<object, object> _valueSetter;
        private IDbValueConverter _dbValueConverter;

        public MRM2(MemberInfo member, IDbValueConverter dbValueConverter)
        {
            this._dbValueConverter = dbValueConverter;
            this._valueSetter = DelegateGenerator.CreateValueSetter(member);
        }

        public void Map(object instance, IDataReader reader, int ordinal)
        {
            object val = reader.GetValue(ordinal);
            val = this._dbValueConverter.Convert(val);
            this._valueSetter(instance, val);
        }
    }
}