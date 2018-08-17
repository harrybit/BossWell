using BossWellModel;
using BossWellModel.Base;
using System;
namespace IBossWellService
{
    public interface ILogService
    {
        QueryResponse<LogEntity> GetPageList(QueryRequest<LogEntity> request);
        LogEntity SaveForm(LogEntity saveModel);
        int DeleteForm(DateTime optionDate);

    }
}
