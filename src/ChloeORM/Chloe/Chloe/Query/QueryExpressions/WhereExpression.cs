using System;
using System.Linq.Expressions;

namespace Chloe.Query.QueryExpressions
{
    internal class WhereExpression : QueryExpression
    {
        private LambdaExpression _predicate;

        public WhereExpression(Type elementType, QueryExpression prevExpression, LambdaExpression predicate)
            : base(QueryExpressionType.Where, elementType, prevExpression)
        {
            this._predicate = predicate;
        }

        public LambdaExpression Predicate
        {
            get { return this._predicate; }
        }

        public override T Accept<T>(QueryExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}