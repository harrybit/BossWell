using System;

namespace Chloe.Query.QueryExpressions
{
    internal abstract class QueryExpression
    {
        private QueryExpression _prevExpression;
        private QueryExpressionType _nodeType;
        private Type _elementType;

        protected QueryExpression(QueryExpressionType nodeType, Type elementType, QueryExpression prevExpression)
            : base()
        {
            this._nodeType = nodeType;
            this._elementType = elementType;
            this._prevExpression = prevExpression;
        }

        public QueryExpression PrevExpression
        {
            get
            {
                return this._prevExpression;
            }
        }

        public virtual QueryExpressionType NodeType
        {
            get
            {
                return this._nodeType;
            }
        }

        public virtual Type ElementType
        {
            get
            {
                return this._elementType;
            }
        }

        public abstract T Accept<T>(QueryExpressionVisitor<T> visitor);
    }
}