using BossWell.Chloe;
using BossWell.Interface;
using BossWell.Model;
using BossWell.Model.Enum;
using System.Collections.Generic;

namespace BossWell.Service
{
    public class RoleAuthorizeService : ChloeProvider, IRoleAuthorizeService
    {
        public QueryResponse<RoleAuthorizeEntity> GetPageList(QueryRequest<RoleAuthorizeEntity> request)
        {
            return Query<RoleAuthorizeEntity>(request);
        }

        public RoleAuthorizeEntity GetSingle(string sid)
        {
            return QuerySing<RoleAuthorizeEntity>(t => t.Sid.Equals(sid));
        }

        public RoleAuthorizeEntity SaveFrom(RoleAuthorizeEntity saveModel)
        {
            return Save(saveModel, "roleauthor_");
        }

        public int DeleteFrom(int sid)
        {
            return _context.Delete<RoleAuthorizeEntity>(t => t.Sid.Equals(sid));
        }

        /// <summary>
        /// 查询用户菜单权限
        /// </summary>
        /// <returns></returns>
        public List<ModuleEntity> GetModuleListByRole(string RoleSid, ModuleEnum moduleType)
        {
            var query = _context.Query<ModuleEntity>().InnerJoin<RoleAuthorizeEntity>((module, author) => module.Sid.Equals(author.ModuleId))
                 .Where((module, author) => author.RoleId.Equals(RoleSid)).Select((module, author) => module);
            if (moduleType != ModuleEnum.未知)
            {
                query = query.Where(t => t.Type == moduleType);
            }
            return query.ToList();

        }

    }
}
