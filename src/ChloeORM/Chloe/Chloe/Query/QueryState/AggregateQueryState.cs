namespace Chloe.Query.QueryState
{
    internal class AggregateQueryState : QueryStateBase, IQueryState
    {
        public AggregateQueryState(ResultElement resultElement)
            : base(resultElement)
        {
        }
    }
}