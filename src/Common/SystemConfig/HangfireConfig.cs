namespace SystemConfig
{
    public class HangfireConfig
    {
        public static string Prefix { get { return "Hangfire"; } }
        public static string RedisStorage { get { return "127.0.0.1:6379"; } }

    }
}
