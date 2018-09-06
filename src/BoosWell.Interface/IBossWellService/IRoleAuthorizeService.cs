using BossWellModel;
using BossWellModel.Base;
using BossWellModel.BossWellModel;
using BossWellModel.Enum;

namespace IBossWellService
{
    public interface IRoleAuthorizeService
    {
        QueryResponse<RoleAuthorizeEntity> GetPageList(QueryRequest<RoleAuthorizeEntity> request);

        QueryResponse<RoleAuthorizeList> GetRoleList(int page, int pageSize);

        RoleAuthorizeEntity GetSingle(string sid);

        int GetCountByRoleId(string roleId, RoleAuthorizeModuleEnum moduleType);

        RoleAuthorizeEntity SaveForm(RoleAuthorizeEntity saveModel);

        void Delete(string sid);
    }
}