namespace BossWell.Configuration
{
    /// <summary>
    /// Redis缓存配置
    /// </summary>
    public class RedisConfiger
    {
        //Redis链接字符串
        public static string WriteServerList
        {
            get
            {
                return "127.0.0.1:6379,allowAdmin=true,abortConnect=false,password=0CD89613B94E98FE4A77A1195CEB7283";
            }
        }

        //Redis服务器地址
        public static string ReadServerList
        {
            get
            {
                return "127.0.0.1:6379";
            }
        }

        //最大连接数(写)
        public static int MaxWritePoolSize
        {
            get
            {
                return 60;
            }
        }

        //最大连接数(读)
        public static int MaxReadPoolSize
        {
            get
            {
                return 60;
            }
        }

        //自动重启
        public static bool AutoStart
        {
            get
            {
                return true;
            }
        }

        //默认缓存时间(秒)
        public static int LocalCacheTime
        {
            get
            {
                return 180;
            }
        }

        //是否记录日志(Redis运行错误时开启)
        public static bool RecordeLog
        {
            get
            {
                return false;
            }
        }

        //默认DB仓库
        public static long DefaultDb
        {
            get
            {
                return 0;
            }
        }
    }
}