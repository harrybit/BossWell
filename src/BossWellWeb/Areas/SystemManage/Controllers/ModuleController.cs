using BossWellApp;
using BossWellModel;
using System.Web.Mvc;
namespace BossWellWeb.Areas.SystemManage.Controllers
{
    public class ModuleController : ControllerBase
    {
        private ModuleApp moduleApp = new ModuleApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson()
        {
            return Content(moduleApp.GetTreeSelectJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeGridJson(string keyword)
        {
            return Content(moduleApp.GetTreeGridJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string sid)
        {
            return Content(moduleApp.GetFormJson(sid));
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ModuleEntity moduleEntity, string sid)
        {
            moduleApp.SubmitForm(moduleEntity, sid);
            return Success("保存成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string sid)
        {
            moduleApp.DeleteForm(sid);
            return Success("删除成功。");
        }
    }
}
