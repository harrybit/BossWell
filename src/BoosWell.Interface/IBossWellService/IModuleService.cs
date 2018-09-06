using BossWellModel;
using BossWellModel.Base;
using System.Collections.Generic;

namespace IBossWellService
{
    public interface IModuleService
    {
        QueryResponse<ModuleEntity> GetPageList(QueryRequest<ModuleEntity> request);

        ModuleEntity GetFormData(string sid);

        int GetChildCount(string parentId);

        List<string> GetChildNodeList(string parentId);

        ModuleEntity SaveModel(ModuleEntity saveEntity);

        int DeleteForm(List<string> idList);

        List<ModuleEntity> GetModuleMenuByRole(string roleId);

        List<ModuleButtonEntity> GetModuleButtonByRole(string roleId);
    }
}