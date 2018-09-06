using BossWellModel;
using BossWellModel.Base;
using BossWellORM;
using IBossWellService;
using System;

namespace BossWellService
{
    public class LogService : ChloeClient, ILogService
    {
        public QueryResponse<LogEntity> GetPageList(QueryRequest<LogEntity> request)
        {
            return Query(request);
        }

        public LogEntity SaveForm(LogEntity saveModel)
        {
            return Save(saveModel, "log_");
        }

        public int DeleteForm(DateTime optionDate)
        {
            return context.Delete<LogEntity>(t => t.CreateDate >= optionDate);
        }
    }
}