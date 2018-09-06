using System.Data;

namespace Chloe.Mapper
{
    public interface IValueSetter
    {
        void SetValue(object obj, IDataReader reader);
    }
}