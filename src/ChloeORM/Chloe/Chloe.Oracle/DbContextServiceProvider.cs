using Chloe.Infrastructure;
using System;
using System.Data;

namespace Chloe.Oracle
{
    internal class DbContextServiceProvider : IDbContextServiceProvider
    {
        private IDbConnectionFactory _dbConnectionFactory;
        private OracleContext _oracleContext;

        public DbContextServiceProvider(IDbConnectionFactory dbConnectionFactory, OracleContext oracleContext)
        {
            this._dbConnectionFactory = dbConnectionFactory;
            this._oracleContext = oracleContext;
        }

        public IDbConnection CreateConnection()
        {
            IDbConnection conn = this._dbConnectionFactory.CreateConnection();
            if ((conn is ChloeOracleConnection) == false)
                conn = new ChloeOracleConnection(conn);
            return conn;
        }

        public IDbExpressionTranslator CreateDbExpressionTranslator()
        {
            if (this._oracleContext.ConvertToUppercase == true)
            {
                return DbExpressionTranslator_ConvertToUppercase.Instance;
            }
            else
            {
                return DbExpressionTranslator.Instance;
            }

            throw new NotSupportedException();
        }
    }
}