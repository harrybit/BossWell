using Chloe.Infrastructure;
using System.Data;

namespace Chloe.MySql
{
    internal class DbContextServiceProvider : IDbContextServiceProvider
    {
        private IDbConnectionFactory _dbConnectionFactory;

        public DbContextServiceProvider(IDbConnectionFactory dbConnectionFactory)
        {
            this._dbConnectionFactory = dbConnectionFactory;
        }

        public IDbConnection CreateConnection()
        {
            return this._dbConnectionFactory.CreateConnection();
        }

        public IDbExpressionTranslator CreateDbExpressionTranslator()
        {
            return DbExpressionTranslator.Instance;
        }
    }
}