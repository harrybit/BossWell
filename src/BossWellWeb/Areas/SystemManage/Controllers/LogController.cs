using BossWellApp;
using BossWellModel;
using System.Web.Mvc;
using ApiHelp;
using BossWellModel.BossWellModel;

namespace BossWellWeb.Areas.SystemManage.Controllers
{
    public class LogController : ControllerBase
    {
        private LogApp logApp = new LogApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            return Content(logApp.GetGridJson(pagination, queryJson));
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRemoveLog(string keepTime)
        {
            logApp.RemoveLog(keepTime);
            return Success("清理成功。");
        }

        [HttpGet]
        public ActionResult RemoveLog()
        {
            return View();
        }
    }
}
