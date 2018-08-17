using BossWellApp;
using System.Web.Mvc;
using BossWellModel;
using System.Collections.Generic;

namespace BossWellWeb.Areas.SystemManage.Controllers
{
    public class RoleController : ControllerBase
    {
        private RoleApp roleApp = new RoleApp();
        private RoleAuthorizeApp roleAuthorizeApp = new RoleAuthorizeApp();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            return Content(roleApp.GetGridListJson(keyword));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson()
        {
            return Content(roleApp.GetTreeSelectJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string sid)
        {
            return Content(roleApp.GetFormData(sid));
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(RoleEntity roleEntity, string moduleLst, string sid)
        {
            int code = roleApp.SubmitForm(roleEntity, moduleLst, sid);
            if (code != 200)
            {
                return Error("Save Error");
            }
            return Success("保存成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            roleApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        [HttpGet]
        public ActionResult GetSelectCateJson()
        {
            List<object> objJson = new List<object>();
            objJson.Add(new { id = 1, text = "系统管理员" });
            objJson.Add(new { id = 2, text = "业务角色" });
            objJson.Add(new { id = 3, text = "其他角色" });
            return Content(ApiHelp.ApiHelper.JsonSerial(objJson));
        }


    }
}
