using  Hangfire;
namespace BossWell.Hangfire
{
    public class JobManage
    {
        public static void RegisterJob()
        {
            //测试用例
            RecurringJob.AddOrUpdate<TestJob>(x => x.Execute(), Cron.DayInterval(1));
        }
    }
}
