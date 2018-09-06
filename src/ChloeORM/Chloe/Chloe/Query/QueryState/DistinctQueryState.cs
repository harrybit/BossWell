using Chloe.DbExpressions;

namespace Chloe.Query.QueryState
{
    internal class DistinctQueryState : SubQueryState
    {
        public DistinctQueryState(ResultElement resultElement)
            : base(resultElement)
        {
        }

        public override DbSqlQueryExpression CreateSqlQuery()
        {
            DbSqlQueryExpression sqlQuery = base.CreateSqlQuery();
            sqlQuery.IsDistinct = true;

            return sqlQuery;
        }
    }
}