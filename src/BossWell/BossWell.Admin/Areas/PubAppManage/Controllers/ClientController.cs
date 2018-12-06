using System.Web.Mvc;
using BossWell.Model;
using BossWell.Application;
using BossWell.Model.Basic;
using System.Collections.Generic;
using BossWell.ApiHelp;
namespace BossWell.Admin.Areas.PubAppManage.Controllers
{
    public class ClientController : ControllerBase
    {
        ClientApplication cltApp = new ClientApplication();

        /// <summary>
        /// 会员分页列表
        /// </summary>
        /// <param name="pagination">分页模型</param>
        /// <param name="keyWord">模糊查询</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetClientPageList(Pagination pagination, string keyWord)
        {
            List<ClientEntity> adminList = cltApp.GetCltPageList(pagination, keyWord);
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
        /// 会员表单数据
        /// </summary>
        /// <param name="keyValue">标识</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            ClientEntity cltEntity = cltApp.GetEntityBySid(keyValue);
            return Content(ApiHelper.JsonSerial(cltEntity));
        }

        /// <summary>
        /// 保存会员信息
        /// </summary>
        /// <param name="bannerEntity">表单模型</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ClientEntity cltEntity)
        {
            bool result = cltApp.SubmitModule(cltEntity);
            if (result) { return Success("保存成功。。。"); }
            return Error("保存失败。。。");
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="keyValue">标识</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            bool result = cltApp.DeleteForm(keyValue);
            if (result) { return Success("删除成功。。。"); }
            return Error("删除失败。。。");
        }
    }
}