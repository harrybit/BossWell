namespace Chloe.DbExpressions
{
    public class DbJoinTableExpression : DbMainTableExpression
    {
        private DbJoinType _joinType;
        private DbExpression _condition;

        public DbJoinTableExpression(DbJoinType joinType, DbTableSegment table, DbExpression condition)
            : base(DbExpressionType.JoinTable, table)
        {
            this._joinType = joinType;
            this._condition = condition;
        }

        public DbJoinType JoinType { get { return this._joinType; } }
        public DbExpression Condition { get { return this._condition; } }

        public override T Accept<T>(DbExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}