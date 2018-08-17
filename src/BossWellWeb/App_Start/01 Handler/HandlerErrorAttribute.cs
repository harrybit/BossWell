using BossWellModel.BossWellModel;
using BossWellModel.Enum;
using System.Web.Mvc;

namespace BossWellWeb
{
    public class HandlerErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            context.ExceptionHandled = true;
            context.HttpContext.Response.StatusCode = 200;
            AjaxResult result = new AjaxResult { state = ResultType.error.ToString(), message = context.Exception.Message };


            context.Result = new ContentResult { Content = ApiHelp.ApiHelper.JsonSerial(result) };
        }
        private void WriteLog(ExceptionContext context)
        {
            //if (context == null)
            //    return;
            //var log = LogFactory.GetLogger(context.Controller.ToString());
            //log.Error(context.Exception);
        }
    }
}