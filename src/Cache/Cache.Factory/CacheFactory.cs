using Cache.Base;
using Cache.Redis;

namespace Cache.Factory
{
    /// <summary>
    /// 缓存工厂
    /// </summary>
    public class CacheFactory
    {
        public static ICache CaChe()
        {
            return new CacheByRedis();
        }
    }
}
