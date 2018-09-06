namespace Chloe.DbExpressions
{
    public class DbOrdering
    {
        private DbOrderType _orderType;
        private DbExpression _expression;

        public DbOrdering(DbExpression expression, DbOrderType orderType)
        {
            this._expression = expression;
            this._orderType = orderType;
        }

        public DbExpression Expression { get { return this._expression; } }
        public DbOrderType OrderType { get { return this._orderType; } }
    }
}