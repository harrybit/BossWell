using System.Web.Http.Filters;
using System.Net.Http;
namespace BossWellApi
{
    /// <summary>
    /// 拦截器
    /// </summary>
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            HttpRequestMessage request = actionContext.Request;
            JObjectResult result = new JObjectResult();
            
            actionContext.Response = HttpResponseExtension.ReturnError(result);
            base.OnActionExecuting(actionContext);

        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }

    }
}