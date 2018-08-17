using BossWellApp;
using BossWellApp.Basic;
using BossWellModel;
using BossWellModel.BossWellModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ApiHelp;
namespace BossWellWeb.Areas.SystemManage.Controllers
{
    public class OrganizeController : ControllerBase
    {
        private OrganizeApp organizeApp = new OrganizeApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson()
        {
            return Content(organizeApp.GetSelectTreeJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeJson()
        {
            return Content(organizeApp.GetTreeJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetSelectCateJson()
        {
            List<object> jsonList = new List<object>();
            jsonList.Add(new { id = 0, text = "集团" });
            jsonList.Add(new { id = 1, text = "公司" });
            jsonList.Add(new { id = 2, text = "部门" });
            jsonList.Add(new { id = 3, text = "小组" });
            return Content(ApiHelper.JsonSerial(jsonList));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeGridJson(string keyword)
        {
            return Content(organizeApp.GetGridTreeJson(keyword));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string sid)
        {
            return Content(organizeApp.GetFormJson(sid));
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(OrganizeEntity organizeEntity, string sid)
        {
            organizeApp.SubmitForm(organizeEntity, sid);
            return Success("保存成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string sid)
        {
            organizeApp.DeleteForm(sid);
            return Success("删除成功。");
        }
    }
}
