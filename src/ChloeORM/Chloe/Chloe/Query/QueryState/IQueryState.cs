using Chloe.Query.Mapping;
using Chloe.Query.QueryExpressions;
using Chloe.Utility;
using System.Linq.Expressions;

namespace Chloe.Query.QueryState
{
    internal interface IQueryState
    {
        MappingData GenerateMappingData();

        ResultElement ToFromQueryResult();

        JoinQueryResult ToJoinQueryResult(JoinType joinType, LambdaExpression conditionExpression, ScopeParameterDictionary scopeParameters, KeyDictionary<string> scopeTables, string tableAlias);

        IQueryState Accept(WhereExpression exp);

        IQueryState Accept(OrderExpression exp);

        IQueryState Accept(SelectExpression exp);

        IQueryState Accept(SkipExpression exp);

        IQueryState Accept(TakeExpression exp);

        IQueryState Accept(AggregateQueryExpression exp);

        IQueryState Accept(GroupingQueryExpression exp);

        IQueryState Accept(DistinctExpression exp);
    }
}