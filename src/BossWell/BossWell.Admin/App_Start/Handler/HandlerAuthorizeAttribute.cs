using BossWell.ApiHelp;
using BossWell.Application;
using System.Text;
using System.Web;
using System.Web.Mvc;
namespace BossWell.Admin
{
    /// <summary>
    /// 管理员操作权限拦截器
    /// </summary>
    public class HandlerAuthorizeAttribute : ActionFilterAttribute
    {
        private RoleAuthorizeApplication authorizeAPP = new RoleAuthorizeApplication();
        public bool Ignore { get; set; }

        public HandlerAuthorizeAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                return;
            }
            if (Ignore == false)
            {
                return;
            }
            if (!this.ActionAuthorize(filterContext))
            {
                StringBuilder sbScript = new StringBuilder();
                sbScript.Append("<script type='text/javascript'>alert('很抱歉！您的权限不足，访问被拒绝！');top.document.location.href='/';</script>");
                filterContext.Result = new ContentResult() { Content = sbScript.ToString() };

                return;
            }
        }

        private bool ActionAuthorize(ActionExecutingContext filterContext)
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var roleId = operatorProvider.RoleId;
            var moduleId = ApiHelper.GetCookie("bosswell_currentmoduleid");
            var action = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();

            return authorizeAPP.CheckAdminRoleAuthor(roleId, moduleId, action);
        }
    }
}