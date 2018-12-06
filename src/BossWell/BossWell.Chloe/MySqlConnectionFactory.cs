using Chloe.Infrastructure;
using Chloe.MySql;
using MySql.Data.MySqlClient;
using System.Data;

namespace BossWell.Chloe
{
    public class MySqlConnectionFactory : IDbConnectionFactory
    {
        private string _connString = null;

        public MySqlConnectionFactory(string connString)
        {
            this._connString = connString;
        }

        public IDbConnection CreateConnection()
        {
            IDbConnection conn = new MySqlConnection(this._connString);
            conn = new ChloeMySqlConnection(conn);
            return conn;
        }
    }
}