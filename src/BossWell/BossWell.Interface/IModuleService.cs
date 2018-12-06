using BossWell.Model;
using System.Collections.Generic;

namespace BossWell.Interface
{
    public interface IModuleService
    {
        QueryResponse<ModuleEntity> GetPageList(QueryRequest<ModuleEntity> request);

        ModuleEntity GetSingle(string sid);

        ModuleEntity SaveFrom(ModuleEntity saveModel);

        List<ModuleEntity> GetModuleChildListBySid(string pSid);

        int DeleteFrom(List<string> sid);

        int SaveBatch(List<ModuleEntity> list);
    }
}
