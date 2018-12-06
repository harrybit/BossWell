using BossWell.ApiHelp;
using BossWell.Model.Basic;
using BossWell.Model.Enum;
using System.Web.Mvc;
namespace BossWell.Admin
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
            AjaxResult result = new AjaxResult { state = ResultTypeEnum.success.ToString(), message = message };

            return Content(ApiHelper.JsonSerial(result));
        }

        protected virtual ActionResult Success(string message, object data)
        {
            AjaxResult result = new AjaxResult { state = ResultTypeEnum.success.ToString(), message = message, data = data };

            return Content(ApiHelper.JsonSerial(result));
        }

        protected virtual ActionResult Error(string message)
        {
            AjaxResult result = new AjaxResult { state = ResultTypeEnum.error.ToString(), message = message };

            return Content(ApiHelper.JsonSerial(result));
        }
    }
}