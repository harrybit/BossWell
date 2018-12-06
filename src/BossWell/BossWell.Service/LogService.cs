using BossWell.Chloe;
using BossWell.Interface;
using BossWell.Model;
using System;

namespace BossWell.Service
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public class LogService : ChloeProvider, ILogService
    {
        public QueryResponse<LogEntity> GetPageList(QueryRequest<LogEntity> request)
        {
            return Query<LogEntity>(request);
        }

        public LogEntity GetSingle(string sid)
        {
            return QuerySing<LogEntity>(t => t.Sid.Equals(sid));
        }

        public LogEntity SaveFrom(LogEntity saveModel)
        {
            return Save(saveModel, "log_");
        }

        public int DeleteFrom(DateTime logCreateDate)
        {
            return _context.Delete<LogEntity>(t => t.CreateDate < logCreateDate);
        }
    }
}
