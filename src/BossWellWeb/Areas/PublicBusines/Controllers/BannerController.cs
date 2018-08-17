using System;
using System.Web.Mvc;
using BossWellModel;
using BossWellApp;
using BossWellModel.BossWellModel;

namespace BossWellWeb.Areas.PublicBusines.Controllers
{
    public class BannerController : ControllerBase
    {
        BannerApp bannerAPP = new BannerApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            return Content(bannerAPP.GetGridJson(pagination, keyword));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            return Content(bannerAPP.GetFormJson(keyValue));
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(BannerEntity bannerEntity, string keyValue)
        {
            bannerAPP.SubmitForm(bannerEntity, keyValue);
            return Success("保存成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            bannerAPP.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}