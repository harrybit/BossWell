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
                return "server=localhost;Database=pureinit;Uid=root;Pwd=Mysql123456.";
            }
        }
    }
}