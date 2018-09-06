using Chloe.Mapper;

namespace Chloe.Query.Mapping
{
    public interface IObjectActivatorCreator
    {
        IObjectActivator CreateObjectActivator();

        IObjectActivator CreateObjectActivator(IDbContext dbContext);
    }
}