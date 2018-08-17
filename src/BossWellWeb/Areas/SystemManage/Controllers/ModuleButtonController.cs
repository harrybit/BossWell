using BossWellApp;
using System.Web.Mvc;
using ApiHelp;
using BossWellModel;

namespace BossWellWeb.Areas.SystemManage.Controllers
{
    public class ModuleButtonController : ControllerBase
    {
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson(string moduleId)
        {
            return Content(moduleButtonApp.GetTreeSelectJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeGridJson(string moduleId)
        {
            return Content(moduleButtonApp.GetTreeGridJson(moduleId));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string sid)
        {
            return Content(moduleButtonApp.GetFormJson(sid));
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ModuleButtonEntity moduleButtonEntity, string sid)
        {
            moduleButtonApp.SubmitForm(moduleButtonEntity, sid);
            return Success("保存成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string sid)
        {
            moduleButtonApp.DeleteForm(sid);
            return Success("删除成功。");
        }

        [HttpGet]
        public ActionResult CloneButton()
        {
            return View();
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetCloneButtonTreeJson()
        {
            return Content(moduleButtonApp.GetTreeCloneButtonJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult SubmitCloneButton(string moduleId, string buttonIDS)
        {
            buttonIDS = buttonIDS.Replace('-', '_');

            int code = moduleButtonApp.SubmitCloneButton(moduleId, buttonIDS);
            if (code == 501)
            {
                return Error("Module Is Null");
            }
            else if (code == 502)
            {
                return Error("Button Is Null");
            }
            else if (code == 503)
            {
                return Error("Save Error");
            }

            return Success("克隆成功。");
        }
    }
}
