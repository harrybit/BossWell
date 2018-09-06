using Hangfire;

namespace PlannedJob
{
    public class JobManage
    {
        public static void RegisterJob()
        {
            RecurringJob.AddOrUpdate<TestJob>(x => x.Execute(), Cron.DayInterval(1));
        }
    }
}