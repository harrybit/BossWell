namespace Chloe.DbExpressions
{
    /// <summary>
    /// T.Name as Alias
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("Alias = {Alias}")]
    public class DbColumnSegment
    {
        private DbExpression _body;
        private string _alias;

        public DbColumnSegment(DbExpression body, string alias)
        {
            this._body = body;
            this._alias = alias;
        }

        /// <summary>
        /// T.Name 部分
        /// </summary>
        public DbExpression Body { get { return this._body; } }

        public string Alias { get { return this._alias; } }
    }
}