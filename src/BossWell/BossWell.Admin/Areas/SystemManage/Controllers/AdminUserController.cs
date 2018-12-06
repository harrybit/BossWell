using System.Web.Mvc;
using BossWell.Model;
using BossWell.Application;
using BossWell.Model.Basic;
using System.Collections.Generic;
using BossWell.ApiHelp;
namespace BossWell.Admin.Areas.SystemManage.Controllers
{
    public class AdminUserController : ControllerBase
    {
        private AdminUserApplication adminUserApp = new AdminUserApplication();
        
        /// <summary>
        /// 后台管理员分页列表
        /// </summary>
        /// <param name="pagination">分页模型</param>
        /// <param name="keyWord">模糊查询</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetAdminUserPageList(Pagination pagination,string keyWord)
        {
            List<AdminUserEntity> adminList = adminUserApp.GetList(pagination, keyWord);
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
        /// 管理员表单数据
        /// </summary>
        /// <param name="keyValue">标识</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            AdminUserEntity adminEntity = adminUserApp.GetEntityBySid(keyValue);
            return Content(ApiHelper.JsonSerial(adminEntity));
        }

        /// <summary>
        /// 保存管理员信息
        /// </summary>
        /// <param name="adminEntity">管理员表单模型</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(AdminUserEntity adminEntity)
        {
            bool result = adminUserApp.SubmitAdminUser(adminEntity);
            if (result) { return Success("保存成功。。。"); }
            return Error("保存失败。。。");
        }

        /// <summary>
        /// 删除管理员
        /// </summary>
        /// <param name="keyValue">标识</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            bool result = adminUserApp.DeleteForm(keyValue);
            if (result) { return Success("删除成功。。。"); }
            return Error("删除失败。。。");
        }

        /// <summary>
        /// 初始化重置密码视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult ResetPassWord()
        {
            return View();
        }

        /// <summary>
        /// 重置管理员登录密码
        /// </summary>
        /// <param name="adminUserSid">管理员标识</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitResetPassWord(string adminUserSid,string passWord)
        {
            bool result = adminUserApp.SubmitAdminUserResetPassWord(adminUserSid,passWord);
            if (result) return Success("重置成功。。。");
            return Error("重置失败。。。");
        }

    }
}