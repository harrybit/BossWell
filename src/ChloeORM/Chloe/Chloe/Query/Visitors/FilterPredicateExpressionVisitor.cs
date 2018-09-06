using Chloe.Core.Visitors;
using Chloe.DbExpressions;
using Chloe.Utility;
using System.Linq.Expressions;

namespace Chloe.Query.Visitors
{
    internal class FilterPredicateExpressionVisitor : ExpressionVisitor<DbExpression>
    {
        public static DbExpression ParseFilterPredicate(LambdaExpression lambda, ScopeParameterDictionary scopeParameters, KeyDictionary<string> scopeTables)
        {
            return GeneralExpressionVisitor.ParseLambda(ExpressionVisitorBase.ReBuildFilterPredicate(lambda), scopeParameters, scopeTables);
        }
    }
}