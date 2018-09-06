using Chloe.Exceptions;
using System;
using System.Data;

namespace Chloe.Mapper
{
    public class MappingFieldActivator : IObjectActivator
    {
        private Func<IDataReader, int, object> _fn = null;
        private int _readerOrdinal;

        public MappingFieldActivator(Func<IDataReader, int, object> fn, int readerOrdinal)
        {
            this._fn = fn;
            this._readerOrdinal = readerOrdinal;
        }

        public object CreateInstance(IDataReader reader)
        {
            try
            {
                return _fn(reader, _readerOrdinal);
            }
            catch (Exception ex)
            {
                throw new ChloeException(ObjectActivator.AppendErrorMsg(reader, this._readerOrdinal, ex), ex);
            }
        }
    }
}