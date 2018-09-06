using System;
using System.Data;

namespace Chloe.DbExpressions
{
    [System.Diagnostics.DebuggerDisplay("Name = {Name}")]
    public class DbColumn
    {
        private string _name;
        private Type _type;
        private DbType? _dbType;
        private int? _size;

        public DbColumn(string name, Type type)
            : this(name, type, null, null)
        {
        }

        public DbColumn(string name, Type type, DbType? dbType, int? size)
        {
            this._name = name;
            this._type = type;
            this._dbType = dbType;
            this._size = size;
        }

        public string Name { get { return this._name; } }
        public Type Type { get { return this._type; } }
        public DbType? DbType { get { return this._dbType; } }
        public int? Size { get { return this._size; } }

        public static DbColumn MakeColumn(DbExpression exp, string alias)
        {
            DbColumn column;
            DbColumnAccessExpression e = exp as DbColumnAccessExpression;
            if (e != null)
                column = new DbColumn(alias, e.Column._type, e.Column._dbType, e.Column._size);
            else
                column = new DbColumn(alias, exp.Type);

            return column;
        }
    }
}