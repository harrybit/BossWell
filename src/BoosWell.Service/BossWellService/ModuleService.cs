
using BossWellORM;
using IBossWellService;
using BossWellModel;
using BossWellModel.Base;
using System.Collections.Generic;
using Chloe;
using BossWellModel.Enum;
using System;

namespace BossWellService
{
    public class ModuleService : ChloeClient, IModuleService
    {
        public QueryResponse<ModuleEntity> GetPageList(QueryRequest<ModuleEntity> request)
        {
            return Query(request);
        }
        public ModuleEntity GetFormData(string sid)
        {
            return context.Query<ModuleEntity>().Where(t => t.Sid.Equals(sid)).FirstOrDefault();
        }
        public int GetChildCount(string parentId)
        {
            return context.Query<ModuleEntity>().Where(t => t.ParentId.Equals(parentId)).Count();
        }
        public List<string> GetChildNodeList(string parentId)
        {
            return context.Query<ModuleEntity>().Where(t => t.ParentId.Equals(parentId)).Select(t => t.Sid).ToList();
        }
        public ModuleEntity SaveModel(ModuleEntity saveEntity)
        {
            return Save<ModuleEntity>(saveEntity, "module_");
        }
        public int DeleteForm(List<string> idList)
        {
            int dltCount = 0;

            context.Session.BeginTransaction();
            context.Delete<ModuleButtonEntity>(t => idList.Contains(t.ModuleSid));
            dltCount = context.Delete<ModuleEntity>(t => idList.Contains(t.Sid));
            context.Session.CommitTransaction();
            return dltCount;
        }
        public List<ModuleEntity> GetModuleMenuByRole(string roleId)
        {
            List<ModuleEntity> list = new List<ModuleEntity>();
            try
            {
                list = context.JoinQuery<RoleAuthorizeEntity, ModuleEntity>((auth, module) => new object[] {
                    JoinType.InnerJoin,auth.ModuleId.Equals(module.Sid)
                }).Where((auth, module) => auth.ModulType == RoleAuthorizeModuleEnum.模块 && auth.RoleId.Equals(roleId))
                .Select((auth, module) => module).OrderBy(t => t.Sort).ToList();

            }
            catch (Exception ex)
            {

            }
            return list;
        }
        public List<ModuleButtonEntity> GetModuleButtonByRole(string roleId)
        {
            List<ModuleButtonEntity> list = new List<ModuleButtonEntity>();
            try
            {
                list = context.JoinQuery<RoleAuthorizeEntity, ModuleButtonEntity>((auth, module) => new object[] {
                    JoinType.InnerJoin,auth.ModuleId.Equals(module.Sid)
                }).Where((auth, module) => auth.ModulType == RoleAuthorizeModuleEnum.按钮 && auth.RoleId.Equals(roleId))
                .Select((auth, module) => module).OrderBy(t => t.Sort).ToList();

            }
            catch (Exception ex)
            {

            }
            return list;
        }

    }
}
