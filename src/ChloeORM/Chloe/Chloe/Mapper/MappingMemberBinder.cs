using System.Data;

namespace Chloe.Mapper
{
    public class MappingMemberBinder : IValueSetter
    {
        private IMRM _mMapper;
        private int _ordinal;

        public MappingMemberBinder(IMRM mMapper, int ordinal)
        {
            this._mMapper = mMapper;
            this._ordinal = ordinal;
        }

        public int Ordinal { get { return this._ordinal; } }

        public void SetValue(object obj, IDataReader reader)
        {
            this._mMapper.Map(obj, reader, this._ordinal);
        }
    }
}