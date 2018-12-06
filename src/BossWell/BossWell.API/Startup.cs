using BossWell.Configuration;
using Hangfire;
using Hangfire.Redis;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using BossWell.API.App_Start;
using  BossWell.Hangfire;
[assembly: OwinStartup(typeof(BossWell.API.Startup))]

namespace BossWell.API
{
    public partial class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            //Hangfire配置
            var doptions = new DashboardOptions
            {
                AuthorizationFilters = new[] {
                    new DontUseThisAuthorizationFilter()
                }
            };

            //Redis数据库配置
            RedisStorageOptions options = new RedisStorageOptions();
            options.Db = 14;
            options.Prefix = "Hangfire_";//前缀
            RedisStorage storage = new RedisStorage(RedisConfiger.WriteServerList, options);

            //Hangfire注册
            app.UseHangfireDashboard("/hangfire", doptions, storage);
            JobStorage.Current = storage;
            app.UseHangfireServer();
            JobManage.RegisterJob();
        }
    }
}