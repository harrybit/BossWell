namespace Chloe.DbExpressions
{
    public class DbDeleteExpression : DbExpression
    {
        private DbTable _table;
        private DbExpression _condition;

        public DbDeleteExpression(DbTable table)
            : this(table, null)
        {
        }

        public DbDeleteExpression(DbTable table, DbExpression condition)
            : base(DbExpressionType.Delete, UtilConstants.TypeOfVoid)
        {
            Utils.CheckNull(table);

            this._table = table;
            this._condition = condition;
        }

        public DbTable Table { get { return this._table; } }
        public DbExpression Condition { get { return this._condition; } }

        public override T Accept<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}