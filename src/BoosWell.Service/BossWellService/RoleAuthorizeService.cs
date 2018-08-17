using Chloe;
using BossWellORM;
using IBossWellService;
using BossWellModel;
using BossWellModel.Base;
using BossWellModel.BossWellModel;
using BossWellModel.Enum;

namespace BossWellService
{
    public class RoleAuthorizeService : ChloeClient, IRoleAuthorizeService
    {
        public QueryResponse<RoleAuthorizeEntity> GetPageList(QueryRequest<RoleAuthorizeEntity> request)
        {
            return Query(request);
        }
        public QueryResponse<RoleAuthorizeList> GetRoleList(int page, int pageSize)
        {
            QueryResponse<RoleAuthorizeList> response = new QueryResponse<RoleAuthorizeList>();

            var query = context.JoinQuery<RoleAuthorizeEntity, ModuleEntity, RoleEntity>
                ((auth, module, role) => new object[] {
                    JoinType.InnerJoin, auth.ModuleId.Equals(module.Sid),
                    JoinType.InnerJoin ,role.Sid.Equals(auth.RoleId)
                }).Where((auth, module, role) => auth.ModulType == BossWellModel.Enum.RoleAuthorizeModuleEnum.模块).
                Select((auth, module, role) => new RoleAuthorizeList()
                {
                    ItemType = (int)auth.ModulType,
                    ModuleFullName = module.FullName,
                    RoleFullName = role.FullName,
                    F_Id = auth.Sid,
                    F_CreatorTime = auth.CreateDate
                });
            response.TotalCount = query.Count();
            response.Items = query.Skip(page * (page - 1)).Take(pageSize).ToList();
            return response;
        }
        public RoleAuthorizeEntity GetSingle(string sid)
        {
            return context.Query<RoleAuthorizeEntity>().Where(t => t.Sid.Equals(sid)).FirstOrDefault();
        }
        public int GetCountByRoleId(string roleId, RoleAuthorizeModuleEnum moduleType)
        {
            return context.Query<RoleAuthorizeEntity>().Where(t => t.RoleId.Equals(roleId) && t.ModulType == moduleType).Count();
        }
        public RoleAuthorizeEntity SaveForm(RoleAuthorizeEntity saveModel)
        {
            return Save(saveModel, "roleauthorize_");
        }
        public void Delete(string sid)
        {
            context.Delete<RoleAuthorizeEntity>(t => t.Sid.Equals(sid));
        }

    }
}
