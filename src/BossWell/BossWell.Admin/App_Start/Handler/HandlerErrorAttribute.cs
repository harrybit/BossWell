using System.Web.Mvc;
using BossWell.Model.Basic;
using BossWell.Model.Enum;
namespace BossWell.Admin
{
    public class HandlerErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            AjaxResult result = new AjaxResult { state = ResultTypeEnum.error.ToString(), message = context.Exception.Message };

            context.Result = new ContentResult { Content = ApiHelp.ApiHelper.JsonSerial(result) };
        }

        private void WriteLog(ExceptionContext context)
        {
        }
    }
}