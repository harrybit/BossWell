namespace SystemConfig
{
    /// <summary>
    /// 数据库相关配置
    /// </summary>
    public class MySqlDataConfig
    {
        //链接对象
        public static string ConnectionString
        {
            get
            {
                //106.14.8.2
                //127.0.0.1
                return "server=106.14.8.2;Database=pureinit;Uid=root;Pwd=0CD89613B94E98FE4A77A1195CEB7283";
            }
        }
    }
}