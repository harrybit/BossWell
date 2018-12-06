using BossWell.Application;
using System.Web.Mvc;

namespace BossWell.Admin
{
    /// <summary>
    /// 登录状态拦截器
    /// </summary>
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        public bool Ignore = true;

        public HandlerLoginAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Ignore == false)
            {
                return;
            }
            if (OperatorProvider.Provider.GetCurrent() == null)
            {
                ApiHelp.ApiHelper.WriteCookie("bosswell_loginerror", "overdue");
                filterContext.HttpContext.Response.Write("<script>top.location.href = '/';</script>");
                return;
            }
        }
    }
}