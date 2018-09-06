using Chloe.DbExpressions;

namespace Chloe.Query
{
    public class JoinQueryResult
    {
        public IMappingObjectExpression MappingObjectExpression { get; set; }
        public DbJoinTableExpression JoinTable { get; set; }
    }
}