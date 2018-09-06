using Chloe.Infrastructure;
using System;
using System.Data;

namespace Chloe.SqlServer
{
    internal class DbContextServiceProvider : IDbContextServiceProvider
    {
        private IDbConnectionFactory _dbConnectionFactory;
        private MsSqlContext _msSqlContext;

        public DbContextServiceProvider(IDbConnectionFactory dbConnectionFactory, MsSqlContext msSqlContext)
        {
            this._dbConnectionFactory = dbConnectionFactory;
            this._msSqlContext = msSqlContext;
        }

        public IDbConnection CreateConnection()
        {
            return this._dbConnectionFactory.CreateConnection();
        }

        public IDbExpressionTranslator CreateDbExpressionTranslator()
        {
            if (this._msSqlContext.PagingMode == PagingMode.ROW_NUMBER)
            {
                return DbExpressionTranslator.Instance;
            }
            else if (this._msSqlContext.PagingMode == PagingMode.OFFSET_FETCH)
            {
                return DbExpressionTranslator_OffsetFetch.Instance;
            }

            throw new NotSupportedException();
        }
    }
}