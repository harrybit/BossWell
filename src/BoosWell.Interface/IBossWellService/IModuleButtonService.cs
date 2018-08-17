using BossWellModel;
using BossWellModel.Base;
using System.Collections.Generic;

namespace IBossWellService
{
    public interface IModuleButtonService
    {
        QueryResponse<ModuleButtonEntity> GetList(QueryRequest<ModuleButtonEntity> request);
        ModuleButtonEntity GetFormData(string sid);
        ModuleButtonEntity SubmitForm(ModuleButtonEntity saveEntity);
        int SubmitBatchForm(List<ModuleButtonEntity> saveList);
        int DeleteForm(string sid);
    }
}
