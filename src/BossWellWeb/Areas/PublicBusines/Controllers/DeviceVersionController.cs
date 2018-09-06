using BossWellApp;
using BossWellModel;
using BossWellModel.BossWellModel;
using System.Web.Mvc;

namespace BossWellWeb.Areas.PublicBusines.Controllers
{
    public class DeviceVersionController : ControllerBase
    {
        private DeviceVersionApp deviceAPP = new DeviceVersionApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            return Content(deviceAPP.GetGridJson(pagination, keyword));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            return Content(deviceAPP.GetFormJson(keyValue));
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(DeviceVersionEntity clientEntity, string keyValue)
        {
            deviceAPP.SubmitForm(clientEntity, keyValue);
            return Success("保存成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            deviceAPP.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}