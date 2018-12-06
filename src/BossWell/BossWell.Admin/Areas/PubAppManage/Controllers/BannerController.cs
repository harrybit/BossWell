using System.Web.Mvc;
using BossWell.Model;
using BossWell.Application;
using BossWell.Model.Basic;
using System.Collections.Generic;
using BossWell.ApiHelp;
namespace BossWell.Admin.Areas.PubAppManage.Controllers
{
    public class BannerController : ControllerBase
    {
        BannerApplication bannerApp = new BannerApplication();

        /// <summary>
        /// 轮播图分页列表
        /// </summary>
        /// <param name="pagination">分页模型</param>
        /// <param name="keyWord">模糊查询</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetBannerPageList(Pagination pagination, string keyWord,string comClassSid)
        {
            List<BannerEntity> adminList = bannerApp.GetBannerPageList(pagination, keyWord, comClassSid);
            var JObject = new
            {
                rows = adminList,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(ApiHelper.JsonSerial(JObject));
        }

        /// <summary>
        /// 轮播图表单数据
        /// </summary>
        /// <param name="keyValue">标识</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            BannerEntity bannerEntity = bannerApp.GetEntityBySid(keyValue);
            return Content(ApiHelper.JsonSerial(bannerEntity));
        }

        /// <summary>
        /// 保存轮播图信息
        /// </summary>
        /// <param name="bannerEntity">表单模型</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(BannerEntity bannerEntity)
        {
            bool result = bannerApp.SubmitModule(bannerEntity);
            if (result) { return Success("保存成功。。。"); }
            return Error("保存失败。。。");
        }

        /// <summary>
        /// 删除轮播图
        /// </summary>
        /// <param name="keyValue">标识</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            bool result = bannerApp.DeleteForm(keyValue);
            if (result) { return Success("删除成功。。。"); }
            return Error("删除失败。。。");
        }
    }
}