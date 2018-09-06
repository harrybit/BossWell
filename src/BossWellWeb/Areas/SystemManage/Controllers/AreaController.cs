using BossWellApp;
using BossWellModel;
using System.Web.Mvc;

namespace BossWellWeb.Areas.SystemManage.Controllers
{
    public class AreaController : ControllerBase
    {
        private AreaApp areaAPP = new AreaApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson()
        {
            return Content(areaAPP.GetSelectTreeJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeGridJson(string keyword)
        {
            return Content(areaAPP.GetGridTreeJson(keyword));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string sid)
        {
            return Content(areaAPP.GetFromDate(sid));
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(AreaEntity areaEntity, string sid)
        {
            areaAPP.SubmitForm(areaEntity, sid);
            return Success("保存成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string sid)
        {
            areaAPP.DeleteForm(sid);
            return Success("删除成功。");
        }
    }
}