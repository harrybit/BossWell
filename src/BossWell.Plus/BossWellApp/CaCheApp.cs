using Cache.Base;
using Cache.Factory;
using System;

namespace BossWellApp
{
    /// <summary>
    /// 缓存操作
    /// </summary>
    public class CaCheApp
    {
        private static readonly ICache _service = CacheFactory.CaChe();

        /// <summary>
        /// 写入缓存
        /// </summary>
        public static void WriteCache(string key, object value)
        {
            _service.Write<object>(key, value, DateTime.Now.AddMinutes(30), CacheId.SMSTempCode);
        }

        /// <summary>
        /// 读取缓存
        /// </summary>
        public static object ReadCache(string key)
        {
            return _service.Read<object>(key, CacheId.SMSTempCode);
        }

        /// <summary>
        /// 清除缓存
        /// </summary>
        public static void RemoveCache(string key)
        {
            _service.Remove(key, CacheId.SMSTempCode);
        }
    }
}