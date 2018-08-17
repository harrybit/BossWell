using BossWellApp;
using BossWellApp.Basic;
using BossWellModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ApiHelp;
using BossWellModel.BossWellModel;

namespace BossWellWeb.Areas.SystemManage.Controllers
{
    public class RoleAuthorizeController : ControllerBase
    {
        private RoleAuthorizeApp authorizeAPP = new RoleAuthorizeApp();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetPermissionTree(string roleId)
        {
            return Content(authorizeAPP.GetPermissionTreeJson(roleId));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetAllMenuList(Pagination pagination)
        {
            return Content(authorizeAPP.GetAllMenuList(pagination));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetSinlge(string keyValue)
        {
            return Content(authorizeAPP.GetForm(keyValue));
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(RoleAuthorizeEntity moduleEntity, string keyValue)
        {
            authorizeAPP.SubmitForm(moduleEntity, keyValue);
            return Success("保存成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            authorizeAPP.DeleteForm(keyValue);
            return Success("删除成功");
        }

        #region  Get Select

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetMenuTypeTreeList()
        {
            List<TreeSelectModel> treeList = new List<TreeSelectModel>();
            treeList.Add(new TreeSelectModel()
            {
                id = "1",
                text = "模块",
                parentId = "0"
            });
            treeList.Add(new TreeSelectModel()
            {
                id = "2",
                text = "按钮",
                parentId = "0"
            });
            treeList.Add(new TreeSelectModel()
            {
                id = "3",
                text = "列表",
                parentId = "0"
            });
            return Content(treeList.TreeSelectJson());
        }

        #endregion

    }
}
