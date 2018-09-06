using Chloe.Query.QueryExpressions;

namespace Chloe.Query
{
    internal abstract class QueryBase
    {
        public abstract QueryExpression QueryExpression { get; }
        public abstract bool TrackEntity { get; }
    }
}