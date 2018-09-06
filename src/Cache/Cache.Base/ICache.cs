using System;

namespace Cache.Base
{
    /// <summary>
    /// 定义缓存接口
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        T Read<T>(string cacheKey, int dbId = 0) where T : class;

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        void Write<T>(string cacheKey, T value, int dbId = 0) where T : class;

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        void Write<T>(string cacheKey, T value, DateTime expireTime, int dbId = 0) where T : class;

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        void Write<T>(string cacheKey, T value, TimeSpan timeSpan, int dbId = 0) where T : class;

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        void Remove(string cacheKey, int dbId = 0);

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        void RemoveAll(int dbId = 0);
    }
}