using BossWellApp;
using BossWellModel;
using System.Web.Mvc;

namespace BossWellWeb.Areas.PublicBusines.Controllers
{
    public class SystemConfigController : ControllerBase
    {
        private SystemConfigApp sysApp = new SystemConfigApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson()
        {
            return Content(sysApp.GetTreeSelectJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeGridJson(string keyword)
        {
            return Content(sysApp.GetTreeGridJson(keyword));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            return Content(sysApp.GetFormJson(keyValue));
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(SystemConfigEntity sysEntity, string keyValue)
        {
            sysApp.SaveForm(sysEntity, keyValue);
            return Success("保存成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            sysApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}