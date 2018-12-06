namespace BossWell.Configuration
{
    /// <summary>
    /// Mysql数据库链接配置
    /// </summary>
    public class MySqlConfiger
    {
        //链接字符串
        public static string ConnectionString
        {
            get
            {
                return "server=localhost;Database=pureinit;Uid=root;Pwd=0CD89613B94E98FE4A77A1195CEB7283;SslMode=none";
            }
        }
    }
}