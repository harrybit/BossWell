using System.Web.Mvc;
using ApiHelp;
using BossWellModel.BossWellModel;
using BossWellModel.Enum;

namespace BossWellWeb
{
    [HandlerLogin]
    public abstract class ControllerBase : Controller
    {

        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Form()
        {
            return View();
        }
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Details()
        {
            return View();
        }
        protected virtual ActionResult Success(string message)
        {
            AjaxResult result = new AjaxResult { state = ResultType.success.ToString(), message = message };


            return Content(ApiHelper.JsonSerial(result));
        }
        protected virtual ActionResult Success(string message, object data)
        {
            AjaxResult result = new AjaxResult { state = ResultType.success.ToString(), message = message, data = data };

            return Content(ApiHelper.JsonSerial(result));
        }
        protected virtual ActionResult Error(string message)
        {
            AjaxResult result = new AjaxResult { state = ResultType.error.ToString(), message = message };

            return Content(ApiHelper.JsonSerial(result));
        }
    }
}
