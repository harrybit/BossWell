using ApiHelp;
using BossWellApp;
using BossWellApp.Basic;
using BossWellModel;
using BossWellModel.BossWellModel;
using BossWellModel.Enum;
using Cache.Base;
using Cache.Factory;
using System;
using System.Web.Mvc;
using SystemConfig;

namespace BossWellWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly LogApp logAPP = new LogApp();
        private readonly AdminUserApp adminUserAPP = new AdminUserApp();
        private readonly AjaxResult result = new AjaxResult();

        public LoginController()
        {
            result.state = ResultTypeEnum.success;
            result.message = "Success";
        }

        [HttpGet]
        public virtual ActionResult Index()
        {
            var test = string.Format("{0:E2}", 1);
            return View();
        }

        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }

        [HttpGet]
        public ActionResult OutLogin()
        {
            var adminUserModel = OperatorProvider.Provider.GetCurrent();
            logAPP.AddSysLog("管理员登录" + adminUserModel.UserName, "后台系统", "安全退出");

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
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(code))
            {
                throw new Exception("请输入账号、密码");
            }

            ICache cacheFac = CacheFactory.CaChe();

            //读取验证码Cache
            string verCode = cacheFac.Read<string>("verCode_" + code.ToLower(),
                CacheId.BossWell_Verifycode);

            if (string.IsNullOrEmpty(verCode) || !verCode.Equals(code.ToLower()))
            {
                result = new AjaxResult { state = ResultTypeEnum.error, message = "验证码错误，请重新输入" };
                return Content(ApiHelper.JsonSerial(result));
            }

            int resultCode = 200;
            password = ApiHelper.MD5Encrypt(password);
            AdminUserEntity adminUserEntity = adminUserAPP.CheckLogin(username, password, ref resultCode);
            if (resultCode != 200)
            {
                result = new AjaxResult { state = ResultTypeEnum.error, message = "账号、密码错误" };
                return Content(ApiHelper.JsonSerial(result));
            }

            OperatorModel operatorModel = new OperatorModel();
            operatorModel.UserId = adminUserEntity.Sid;
            operatorModel.UserCode = adminUserEntity.Account;
            operatorModel.UserName = adminUserEntity.NickName;
            operatorModel.CompanyId = adminUserEntity.OrganizeSid;
            operatorModel.DepartmentId = string.IsNullOrEmpty(adminUserEntity.HeadIcon) ?
                "~/Content/img/samples/scarlet-159.png" : adminUserEntity.HeadIcon;
            operatorModel.RoleId = adminUserEntity.RoleSid;
            operatorModel.LoginIPAddress = ApiHelper.GetClientIP();
            operatorModel.LoginIPAddressName = string.Empty;
            operatorModel.LoginTime = DateTime.Now;
            operatorModel.LoginToken = ApiHelper.SHA256(ApiHelper.CreateRandomString(32));
            operatorModel.IsSystem = adminUserEntity.Account.Equals(PlatPublicConfig.AdminName) ? true : false;
            OperatorProvider.Provider.AddCurrent(operatorModel);
            //清除验证码缓存
            cacheFac.Remove("verCode_" + code.ToLower(), CacheId.BossWell_Verifycode);
            logAPP.AddSysLog("Login", "后台系统", "登录成功");
            result = new AjaxResult { state = ResultTypeEnum.success, message = "登录成功。" };
            return Content(ApiHelper.JsonSerial(result));
        }
    }
}