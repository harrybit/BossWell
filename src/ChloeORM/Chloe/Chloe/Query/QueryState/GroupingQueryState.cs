using Chloe.Query.QueryExpressions;

namespace Chloe.Query.QueryState
{
    internal class GroupingQueryState : QueryStateBase
    {
        public GroupingQueryState(ResultElement resultElement)
            : base(resultElement)
        {
        }

        public override IQueryState Accept(WhereExpression exp)
        {
            IQueryState state = this.AsSubQueryState();
            return state.Accept(exp);
        }

        public override IQueryState Accept(AggregateQueryExpression exp)
        {
            IQueryState state = this.AsSubQueryState();
            return state.Accept(exp);
        }

        public override IQueryState Accept(GroupingQueryExpression exp)
        {
            IQueryState state = this.AsSubQueryState();
            return state.Accept(exp);
        }
    }
}