using System;
using StackExchange.Redis;
using ApiHelp;
using SystemConfig;
namespace Cache.Redis
{
    public class RedisCache
    {
        private static string Constring = RedisConfig.WriteServerList;
        private static readonly object locker = new object();
        private static ConnectionMultiplexer _instance;

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

        public static bool Set<T>(string key, T t, int dbId = 0)
        {
            var db = GetDataBase(dbId);
            string json = ApiHelper.JsonSerial(t);
            return db.StringSet(key, json);
        }
        
        public static bool Set<T>(string key, T t, TimeSpan timeSpan, int dbId = 0)
        {
            var db = GetDataBase(dbId);
            string json = ApiHelper.JsonSerial(t);
            return db.StringSet(key, json, timeSpan);
        }
        
        public static bool Set<T>(string key, T t, DateTime dateTime, int dbId = 0)
        {
            var db = GetDataBase(dbId);
            string json = ApiHelper.JsonSerial(t);
            return db.StringSet(key, json, dateTime - DateTime.Now);
        }

        public static T Get<T>(string key, int dbId = 0) where T : class
        {
            var db = GetDataBase(dbId);
            var value = db.StringGet(key);
            return db.StringGet(key).IsNullOrEmpty ? default(T) : ApiHelper.JsonDeserial<T>(value.ToString());
        }
        
        public static bool Remove(string key, int dbId = 0)
        {
            var db = GetDataBase(dbId);
            return db.KeyDelete(key);
        }
        
        public static void RemoveAll(int dbId = 0)
        {
            Instance.GetServer(RedisConfig.ReadServerList).FlushDatabase(dbId);
        }
    }
}
