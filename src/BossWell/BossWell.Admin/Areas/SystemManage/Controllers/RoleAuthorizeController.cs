using BossWell.Application;
using BossWell.Model;
using BossWell.Model.Basic;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BossWell.Admin.Areas.SystemManage.Controllers
{
    public class RoleAuthorizeController : ControllerBase
    {
        private RoleAuthorizeApplication roleAuthorAPP = new RoleAuthorizeApplication();

        /// <summary>
        /// 角色权限树
        /// </summary>
        /// <param name="roleId">角色Sid</param>
        /// <returns></returns>
        public ActionResult GetRoleAuthorTreeList(string roleId)
        {
            List<TreeViewModel> treeList = new List<TreeViewModel>();

            //全部模块
            List<ModuleEntity> moduleList = roleAuthorAPP.GetMenuListByRoleId(string.Empty, Model.Enum.ModuleEnum.未知, true);
            //角色对应群贤
            List<RoleAuthorizeEntity> roleAuthorList = new List<RoleAuthorizeEntity>();
            if (!string.IsNullOrEmpty(roleId)) roleAuthorList = roleAuthorAPP.GetAuthorListByRoleSid(roleId);

            moduleList.ForEach(delegate (ModuleEntity item)
            {
                int childCount = 0;
                if (!string.IsNullOrEmpty(roleId)) { childCount = roleAuthorList.Where(t => t.ModuleId.Equals(item.Sid)).Count(); }
                treeList.Add(new TreeViewModel()
                {
                    id = item.Sid,
                    text = item.FullName,
                    value = string.Empty,
                    parentId = item.ParentId,
                    isexpand = true,
                    complete = true,
                    showcheck = true,
                    checkstate = childCount,
                    hasChildren = item.Type == Model.Enum.ModuleEnum.模块 ? true : false,
                    img = item.Icon
                });
            });
            return Content(treeList.TreeViewJson());
        }

    }
}