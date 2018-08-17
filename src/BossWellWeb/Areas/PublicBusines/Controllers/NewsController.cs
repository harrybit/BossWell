using System;
using System.Web.Mvc;
using BossWellModel;
using BossWellApp;
using BossWellModel.BossWellModel;
namespace BossWellWeb.Areas.PublicBusines.Controllers
{
    public class NewsController : ControllerBase
    {
        NewsApp newsAPP = new NewsApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            return Content(newsAPP.GetGridJson(pagination, keyword));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            return Content(newsAPP.GetFormJson(keyValue));
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(NewsEntity newsEntity, string keyValue)
        {
            newsAPP.SubmitForm(newsEntity, keyValue);
            return Success("保存成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            newsAPP.DeleteForm(keyValue);
            return Success("删除成功。");
        }

    }
}