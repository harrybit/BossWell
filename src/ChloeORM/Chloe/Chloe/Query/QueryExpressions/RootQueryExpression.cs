using System;

namespace Chloe.Query.QueryExpressions
{
    internal class RootQueryExpression : QueryExpression
    {
        private string _explicitTable;

        public RootQueryExpression(Type elementType, string explicitTable)
            : base(QueryExpressionType.Root, elementType, null)
        {
            this._explicitTable = explicitTable;
        }

        public string ExplicitTable { get { return this._explicitTable; } }

        public override T Accept<T>(QueryExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}