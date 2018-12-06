using BossWell.ApiHelp;
using BossWell.Application;
using BossWell.Model;
using BossWell.Model.Basic;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace BossWell.Admin.Areas.SystemManage.Controllers
{
    public class RoleController : ControllerBase
    {
        private RoleApplication roleAPP = new RoleApplication();

        /// <summary>
        /// 角色列表
        /// </summary>
        /// <param name="keyword">模糊查询</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetAllRoleList(string keyword)
        {
            List<RoleEntity> list = roleAPP.GetAllModuleListByType(keyword);
            return Content(ApiHelper.JsonSerial(list));
        }

        /// <summary>
        /// 角色下拉树列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetSelectTreeList()
        {
            List<TreeSelectModel> list = roleAPP.GetAllModuleListByType(string.Empty).Select(t => new TreeSelectModel()
            {
                id = t.Sid,
                text = t.FullName,
                parentId = "0"
            }).ToList();
            return Content(list.TreeSelectJson());
        }

        /// <summary>
        /// 角色表单数据
        /// </summary>
        /// <param name="keyValue">标识</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            RoleEntity roleEntity = roleAPP.GetEntityBySid(keyValue);
            return Content(ApiHelper.JsonSerial(roleEntity));
        }

        /// <summary>
        /// 保存角色及权限
        /// </summary>
        /// <param name="roleEntity">角色表单模型</param>
        /// <param name="authorIds">权限Sid</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(RoleEntity roleEntity, string authorIds)
        {
            bool result = roleAPP.SubmitModule(roleEntity, authorIds);
            if (result) { return Success("保存成功。。。"); }
            return Error("保存失败。。。");
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="keyValue">标识</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            bool result = roleAPP.DeleteForm(keyValue);
            if (result) { return Success("删除成功。。。"); }
            return Error("删除失败。。。");
        }

    }
}