namespace BossWell.Cache
{
    public class CacheFactory
    {
        /// <summary>
        /// Redis
        /// </summary>
        /// <returns></returns>
        public static ICacheRedis GetCacheRedis()
        {
            return new CacheRedis();
        }
    }
}
