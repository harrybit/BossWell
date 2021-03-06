﻿using System;
namespace BossWell.Cache
{
    public class CacheRedis:ICacheRedis
    {
        /// <summary>
        /// 读取缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        /// <returns></returns>
        public T Read<T>(string cacheKey, int dbId = 0) where T : class
        {
            return RedisConnection.Get<T>(cacheKey, dbId);
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        public void Write<T>(string cacheKey, T value, int dbId = 0) where T : class
        {
            RedisConnection.Set(cacheKey, value, dbId);
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="expireTime">到期时间</param>
        public void Write<T>(string cacheKey, T value, DateTime expireTime, int dbId = 0) where T : class
        {
            RedisConnection.Set(cacheKey, value, expireTime, dbId);
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="value">对象数据</param>
        /// <param name="cacheKey">键</param>
        /// <param name="TimeSpan">缓存时间</param>
        public void Write<T>(string cacheKey, T value, TimeSpan timeSpan, int dbId = 0) where T : class
        {
            RedisConnection.Set(cacheKey, value, timeSpan, dbId);
        }

        /// <summary>
        /// 移除指定数据缓存
        /// </summary>
        /// <param name="cacheKey">键</param>
        public void Remove(string cacheKey, int dbId = 0)
        {
            RedisConnection.Remove(cacheKey, dbId);
        }

        /// <summary>
        /// 移除全部缓存
        /// </summary>
        public void RemoveAll(int dbId = 0)
        {
            RedisConnection.RemoveAll(dbId);
        }
    }
}
