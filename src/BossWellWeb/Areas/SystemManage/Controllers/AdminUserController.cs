using BossWellApp;
using BossWellModel;
using BossWellModel.BossWellModel;
using System.Web.Mvc;

namespace BossWellWeb.Areas.SystemManage.Controllers
{
    public class AdminUserController : ControllerBase
    {
        private readonly AdminUserApp adminUserAPP = new AdminUserApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            return Content(adminUserAPP.GetGridJsonList(pagination, keyword));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string sid)
        {
            return Content(adminUserAPP.GetFormJsonData(sid));
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(AdminUserEntity entity, string sid)
        {
            adminUserAPP.SubmitForm(entity, sid);
            return Success("保存成功。");
        }

        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string sid)
        {
            adminUserAPP.DeleteForm(sid);
            return Success("删除成功。");
        }

        [HttpGet]
        public ActionResult ResetPwd()
        {
            return View();
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitResetPwd(string userPassword, string sid)
        {
            adminUserAPP.ResetPwd(userPassword, sid);
            return Success("重置成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DisabledAccount(string sid)
        {
            adminUserAPP.DisEnableAccount(false, sid);
            return Success("账户禁用成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult EnabledAccount(string sid)
        {
            adminUserAPP.DisEnableAccount(true, sid);
            return Success("账户启用成功。");
        }
    }
}