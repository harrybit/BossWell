using BossWellApp;
using BossWellModel;
using BossWellModel.BossWellModel;
using System.Web.Mvc;

namespace BossWellWeb.Areas.PublicBusines.Controllers
{
    public class ClientController : ControllerBase
    {
        private ClientApp cltAPP = new ClientApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            return Content(cltAPP.GetGridJson(pagination, keyword));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            return Content(cltAPP.GetFormJson(keyValue));
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ClientEntity clientEntity, string keyValue)
        {
            cltAPP.SubmitForm(clientEntity, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            cltAPP.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}