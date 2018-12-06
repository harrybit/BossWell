using BossWell.Model;
using BossWell.Model.Enum;
using System.Collections.Generic;

namespace BossWell.Interface
{
    public interface IRoleAuthorizeService
    {
        QueryResponse<RoleAuthorizeEntity> GetPageList(QueryRequest<RoleAuthorizeEntity> request);

        RoleAuthorizeEntity GetSingle(string sid);

        RoleAuthorizeEntity SaveFrom(RoleAuthorizeEntity saveModel);

        int DeleteFrom(int sid);

        List<ModuleEntity> GetModuleListByRole(string RoleSid, ModuleEnum moduleType);
    }
}
