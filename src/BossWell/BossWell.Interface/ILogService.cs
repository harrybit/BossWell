using BossWell.Model;
using System;

namespace BossWell.Interface
{
    public interface ILogService
    {
        QueryResponse<LogEntity> GetPageList(QueryRequest<LogEntity> request);

        LogEntity GetSingle(string sid);

        LogEntity SaveFrom(LogEntity saveModel);

        int DeleteFrom(DateTime logCreateDate);
    }
}
