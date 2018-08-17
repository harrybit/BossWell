using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Hangfire;
using PlannedJob;
using Hangfire.Redis;
using SystemConfig;

[assembly: OwinStartup(typeof(BossWellApi.Startup))]

namespace BossWellApi
{
    public partial class Startup
    {
        public static HttpConfiguration HttpConfiguration { get; private set; }
        public void Configuration(IAppBuilder app)
        {
            //Hangfire配置
            //权限
            var doptions = new DashboardOptions
            {
                AuthorizationFilters = new[] {
                    new DontUseThisAuthorizationFilter()
                }
            };
            //Redis数据库配置
            RedisStorageOptions options = new RedisStorageOptions();
            options.Db = 14;
            options.Prefix = HangfireConfig.Prefix;//前缀
            RedisStorage storage = new RedisStorage(HangfireConfig.RedisStorage, options);

            //仪表盘服务
            app.UseHangfireDashboard("/hangfire", doptions, storage);
            JobStorage.Current = storage;
            app.UseHangfireServer();
            //注册服务
            JobManage.RegisterJob();
        }
    }
}
