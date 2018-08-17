using System;
using System.Collections.Generic;
using System.Linq;
using BossWellApp.Basic;
using BossWellFactory;
using IBossWellService;
using BossWellModel;
using BossWellModel.BossWellModel;
using Cache.Base;
using Cache.Factory;
using BossWellModel.Base;
using BossWellModel.Enum;
using ApiHelp;
namespace BossWellApp
{
    public class RoleAuthorizeApp
    {
        private IRoleAuthorizeService _service = SysAutoFactory.GetRoleAuthorizeService();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        /// <summary>
        /// Get Role Permission
        /// </summary>
        public string GetPermissionTreeJson(string roleId)
        {
            List<ModuleEntity> moduleList = moduleApp.GetAllList();
            List<ModuleButtonEntity> moduleButtonList = moduleButtonApp.GetButtonListByModuleId();
            List<RoleAuthorizeEntity> authorizeList = new List<RoleAuthorizeEntity>();
            if (!string.IsNullOrEmpty(roleId))
            {
                authorizeList = GetRoleAuthorizeByRoleId(roleId);
            }
            List<TreeViewModel> treeViewList = new List<TreeViewModel>();

            //模块元素
            moduleList.ForEach(delegate (ModuleEntity item)
            {
                treeViewList.Add(new TreeViewModel()
                {
                    id = item.Sid,
                    text = item.FullName,
                    value = item.EnCode,
                    parentId = item.ParentId,
                    isexpand = true,
                    complete = true,
                    showcheck = true,
                    checkstate = authorizeList.Count(t => t.ModuleId.Equals(item.Sid)),
                    hasChildren = true,
                    img = (string.IsNullOrEmpty(item.Icon) ? string.Empty : item.Icon)
                });
            });
            moduleButtonList.ForEach(delegate (ModuleButtonEntity buttonItem)
            {
                treeViewList.Add(new TreeViewModel()
                {
                    id = buttonItem.Sid,
                    text = buttonItem.FullName,
                    value = buttonItem.EnCode,
                    parentId = buttonItem.ModuleSid,
                    isexpand = true,
                    complete = true,
                    showcheck = true,
                    checkstate = authorizeList.Count(t => t.ModuleId.Equals(buttonItem.Sid)),
                    hasChildren = false,
                    img = string.Empty
                });
            });
            return treeViewList.TreeViewJson();
        }

        /// <summary>
        /// Get All Model
        /// </summary>
        /// <returns></returns>
        public string GetAllMenuList(Pagination option)
        {
            QueryResponse<RoleAuthorizeList> response = _service.GetRoleList(option.page, option.rows);
            option.records = response.TotalCount;
            var JsonObj = new
            {
                rows = response.Items,
                total = option.total,
                page = option.page,
                records = option.records
            };
            return ApiHelper.JsonSerial(JsonObj);
        }

        /// <summary>
        /// Get Single
        /// </summary>
        /// <returns></returns>
        public string GetForm(string sid)
        {
            return ApiHelper.JsonSerial(_service.GetSingle(sid));
        }

        /// <summary>
        /// Save
        /// </summary>
        public void SubmitForm(RoleAuthorizeEntity authorEntity, string sid)
        {
            if (!string.IsNullOrEmpty(sid))
            {
                RoleAuthorizeEntity editModel = _service.GetSingle(sid);
                if (editModel != null)
                {
                    authorEntity.Sid = editModel.Sid;
                    authorEntity.CreateDate = editModel.CreateDate;
                }
            }
            _service.SaveForm(authorEntity);
        }

        /// <summary>
        /// Delete
        /// </summary>
        public void DeleteForm(string sid)
        {
            _service.Delete(sid);
        }

        /// <summary>
        /// Check Role Authorize 
        /// </summary>
        public bool ActionValidate(string roleId, string moduleId, string action)
        {
            ICache cacheFac = CacheFactory.CaChe();
            List<AuthorizeActionModel> authorizeurldata = new List<AuthorizeActionModel>();
            List<AuthorizeActionModel> cachedata = cacheFac.Read<List<AuthorizeActionModel>>("authorizeurldata_" + roleId,
                CacheId.RoleAuthorize);

            //缓存失效、角色权限变更重新写入缓存
            if (cachedata == null || cachedata.Count < 1)
            {
                authorizeurldata = GetMenuByRoleId(roleId);
                cacheFac.Write("authorizeurldata_" + roleId, authorizeurldata, DateTime.Now.AddDays(1), CacheId.RoleAuthorize);
            }
            else
            {
                //角色权限变化
                if (_service.GetCountByRoleId(roleId, RoleAuthorizeModuleEnum.模块) != cachedata.Count)
                {
                    authorizeurldata = GetMenuByRoleId(roleId);
                }
                else
                {
                    authorizeurldata = cachedata;
                }
            }

            authorizeurldata = authorizeurldata.FindAll(t => t.Sid.Equals(moduleId));
            foreach (AuthorizeActionModel item in authorizeurldata)
            {
                if (string.IsNullOrEmpty(item.Path)) { continue; }
                if (item.Sid.Equals(moduleId)) { return true; }
            }
            return false;
        }

        private List<AuthorizeActionModel> GetMenuByRoleId(string roleId)
        {
            List<AuthorizeActionModel> list = new List<AuthorizeActionModel>();
            List<ModuleEntity> moduleList = moduleApp.GetModuleMenuByRole(roleId);
            moduleList.ForEach(delegate (ModuleEntity item)
            {
                list.Add(new AuthorizeActionModel()
                {
                    Sid = item.Sid,
                    Path = item.Path
                });
            });
            return list;
        }

        private List<RoleAuthorizeEntity> GetRoleAuthorizeByRoleId(string roleId)
        {
            if (string.IsNullOrEmpty(roleId)) { return new List<RoleAuthorizeEntity>(); }

            QueryRequest<RoleAuthorizeEntity> request = new QueryRequest<RoleAuthorizeEntity>();
            request.expression = (t => t.RoleId.Equals(roleId) && t.RoleType == RoleCateEnum.系统管理员);
            request.Page = 1;
            request.PageSize = 10000;
            request.Sort = (t => t.Sort);
            return _service.GetPageList(request).Items;
        }

    }
}
