using BossWellModel;
using BossWellModel.Base;
using System.Collections.Generic;

namespace IBossWellService
{
    public interface IRoleService
    {
        QueryResponse<RoleEntity> GetPageList(QueryRequest<RoleEntity> request);
        RoleEntity GetFormData(string Sid);
        void SubmitForm(RoleEntity roleEntity, List<RoleAuthorizeEntity> authorList);
        int Delete(string sid);
    }
}
