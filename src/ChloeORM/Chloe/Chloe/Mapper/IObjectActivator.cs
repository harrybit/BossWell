using System.Data;

namespace Chloe.Mapper
{
    public interface IObjectActivator
    {
        object CreateInstance(IDataReader reader);
    }
}