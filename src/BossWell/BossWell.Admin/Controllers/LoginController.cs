using BossWell.ApiHelp;
using BossWell.Application;
using BossWell.Model;
using BossWell.Model.Basic;
using BossWell.Model.Enum;
using System;
using System.Web.Mvc;

namespace BossWell.Admin.Controllers
{
    public class LoginController : Controller
    {
        private AdminUserApplication adminUserAPP = new AdminUserApplication();
        private LogApplication logAPP = new LogApplication();

        [HttpGet]
        public virtual ActionResult Index()
        {
            var test = string.Format("{0:E2}", 1);
            return View();
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return Content(string.Empty);
        }

        [HttpGet]
        public ActionResult OutLogin()
        {
            var loginInfo = OperatorProvider.Provider.GetCurrent();
            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            AjaxResult result = new AjaxResult();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                result = new AjaxResult { state = ResultTypeEnum.error, message = "请输入账号、密码" };
                return Content(ApiHelper.JsonSerial(result));
            }
            password = ApiHelper.MD5Encrypt(password,"MD5");
            AdminUserEntity adminUserEntity = adminUserAPP.CheckAdminLoginState(username, password);

            if (adminUserEntity == null)
            {
                result = new AjaxResult { state = ResultTypeEnum.error, message = "账号、密码错误" };
                return Content(ApiHelper.JsonSerial(result));
            }
            else if (!adminUserEntity.IsEnable)
            {
                result = new AjaxResult { state = ResultTypeEnum.error, message = "此账号已被禁用" };
                return Content(ApiHelper.JsonSerial(result));
            }
            OperatorModel operatorModel = new OperatorModel();
            operatorModel.UserId = adminUserEntity.Sid;
            operatorModel.UserName = adminUserEntity.NickName;
            operatorModel.RoleId = adminUserEntity.RoleSid;
            operatorModel.LoginTime = DateTime.Now;
            operatorModel.LoginToken = ApiHelper.SHA256(ApiHelper.CreateRandomString(32));
            operatorModel.IsSystem = adminUserEntity.Account.Equals("admin") ? true : false;
            operatorModel.HeadIcon = adminUserEntity.HeadIcon;
            OperatorProvider.Provider.AddCurrent(operatorModel);

            logAPP.AddLog("登录成功_" + adminUserEntity.NickName, "后台系统", LogEnum.系统日志, "登录成功。。。");
            result = new AjaxResult { state = ResultTypeEnum.success, message = "登录成功。" };
            return Content(ApiHelper.JsonSerial(result));
        }
    }
}