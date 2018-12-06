using BossWell.Cache;
using BossWell.Domain;
using BossWell.Interface;
using BossWell.Model;
using BossWell.Model.Admin;
using BossWell.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BossWell.Application
{
    public class RoleAuthorizeApplication
    {
        private IRoleAuthorizeService _service = SysAuthFactory.GetRoleAuthorService();
        private ICacheRedis _cacheService = CacheFactory.GetCacheRedis();
        private ModuleApplication moduleAPP = new ModuleApplication();
        /// <summary>
        /// 角色权限列表
        /// </summary>
        /// <param name="roleSid">角色Sid</param>
        /// <returns></returns>
        public List<RoleAuthorizeEntity> GetAuthorListByRoleSid(string roleSid)
        {
            QueryRequest<RoleAuthorizeEntity> request = new QueryRequest<RoleAuthorizeEntity>();
            request.Expression = t => t.RoleId.Equals(roleSid);
            request.Page = 1;
            request.PageSize = int.MaxValue;
            request.Sort = "CreateDate asc";
            return _service.GetPageList(request).Items.ToList();
        }

        /// <summary>
        /// 角色对应菜单权限
        /// </summary>
        /// <param name="roleSid">角色Sid</param>
        /// <param name="moduleType">菜单类型</param>
        /// <param name="isSys">是否系统管理员</param>
        /// <returns></returns>
        public List<ModuleEntity> GetMenuListByRoleId(string roleSid, ModuleEnum moduleType = ModuleEnum.未知,bool isSys=false)
        {
            if (isSys) { return moduleAPP.GetAllModuleListByType(moduleType,string.Empty); }

            return _service.GetModuleListByRole(roleSid, moduleType);
        }

        /// <summary>
        /// 检测管理员角色权限
        /// </summary>
        /// <param name="roleSid">角色</param>
        /// <param name="moduleSid">模块</param>
        /// <param name="action">操作Url</param>
        /// <returns></returns>
        public bool CheckAdminRoleAuthor(string roleSid, string moduleSid, string action)
        {
            if (string.IsNullOrEmpty(roleSid) || string.IsNullOrEmpty(moduleSid)) { return false; }

            List<RoleAuthorizeMenuModel> authorList = new List<RoleAuthorizeMenuModel>();

            //Get Cache
            List<RoleAuthorizeMenuModel> cacheAuthorList = _cacheService.Read<List<RoleAuthorizeMenuModel>>("authorizeadmin_" + roleSid, CacheId.RoleAuthorize);
            authorList = cacheAuthorList;
            if (cacheAuthorList == null || cacheAuthorList.Count < 1)
            {
                authorList = GetMenuListByRoleId(roleSid, ModuleEnum.模块).Select(t => new RoleAuthorizeMenuModel { Sid = t.Sid, Path = t.Path }).ToList();
                _cacheService.Write("authorizeadmin_" + roleSid, authorList, DateTime.Now.AddDays(7), CacheId.RoleAuthorize);
            }
            else
            {
                List<ModuleEntity> roleModuleList = GetMenuListByRoleId(roleSid, ModuleEnum.模块);
                if (cacheAuthorList.Count != roleModuleList.Count)
                {
                    authorList = roleModuleList.Select(t => new RoleAuthorizeMenuModel { Sid = t.Sid, Path = t.Path }).ToList();
                    _cacheService.Write("authorizeadmin_" + roleSid, authorList, DateTime.Now.AddDays(7), CacheId.RoleAuthorize);
                }
            }

            //是否有权限操作
            if (authorList.Where(t => t.Sid.Equals(moduleSid)).Count() < 1)
            {
                return false;
            }

            return true;
        }

    }
}
