using BossWell.ApiHelp;
using BossWell.Configuration;
using StackExchange.Redis;
using System;
namespace BossWell.Cache
{
    public class RedisConnection
    {
        private static string Constring = RedisConfiger.WriteServerList;//Redis连接对象
        private static readonly object locker = new object();//线程锁
        private static ConnectionMultiplexer _instance;

        /// <summary>
        /// 单例模式获取redis连接实例
        /// </summary>
        public static ConnectionMultiplexer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (locker)
                    {
                        if (_instance == null || !_instance.IsConnected)
                            _instance = GetManager();
                    }
                }
                return _instance;
            }
        }

        private static ConnectionMultiplexer GetManager(string constr = null)
        {
            constr = constr ?? Constring;
            var connect = ConnectionMultiplexer.Connect(constr);
            return connect;
        }

        public static IDatabase GetDataBase(int dbId = 0)
        {
            return Instance.GetDatabase(dbId);
        }

        /// <summary>
        /// 设置单体
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="key">键值</param>
        /// <param name="t">值</param>
        /// <param name="dbId">库Id</param>
        /// <returns></returns>
        public static bool Set<T>(string key, T t, int dbId = 0)
        {
            var db = GetDataBase(dbId);
            string json = ApiHelper.JsonSerial(t);
            return db.StringSet(key, json);
        }

        /// <summary>
        /// 设置单体
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="key">键值</param>
        /// <param name="t">值</param>
        /// <param name="timeSpan">保存时间</param>
        /// <param name="dbId">库Id</param>
        /// <returns></returns>
        public static bool Set<T>(string key, T t, TimeSpan timeSpan, int dbId = 0)
        {
            var db = GetDataBase(dbId);
            string json = ApiHelper.JsonSerial(t);
            return db.StringSet(key, json, timeSpan);
        }

        /// <summary>
        /// 设置单体
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="key">键值</param>
        /// <param name="t">值</param>
        /// <param name="dateTime">过期时间</param>
        /// <returns></returns>
        public static bool Set<T>(string key, T t, DateTime dateTime, int dbId = 0)
        {
            var db = GetDataBase(dbId);
            string json = ApiHelper.JsonSerial(t);
            return db.StringSet(key, json, dateTime - DateTime.Now);
        }

        /// <summary>
        /// 获取单体
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="key">键值</param>
        /// <returns></returns>
        public static T Get<T>(string key, int dbId = 0) where T : class
        {
            var db = GetDataBase(dbId);
            var value = db.StringGet(key);
            return db.StringGet(key).IsNullOrEmpty ? default(T) : ApiHelper.JsonDeserial<T>(value.ToString());
        }

        /// <summary>
        /// 移除单体
        /// </summary>
        /// <param name="key">键值</param>
        public static bool Remove(string key, int dbId = 0)
        {
            var db = GetDataBase(dbId);
            return db.KeyDelete(key);
        }

        /// <summary>
        /// 清空所有缓存
        /// </summary>
        public static void RemoveAll(int dbId = 0)
        {
            Instance.GetServer(RedisConfiger.ReadServerList).FlushDatabase(dbId);
        }

    }
}
