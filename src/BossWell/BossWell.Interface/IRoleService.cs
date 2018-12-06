using BossWell.Model;
using System.Collections.Generic;

namespace BossWell.Interface
{
    public interface IRoleService
    {
        QueryResponse<RoleEntity> GetPageList(QueryRequest<RoleEntity> request);

        RoleEntity GetSingle(string sid);

        RoleEntity SaveFrom(RoleEntity saveModel, List<RoleAuthorizeEntity> authList);

        int DeleteFrom(string sid);
    }
}
