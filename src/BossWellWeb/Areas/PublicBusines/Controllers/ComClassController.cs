using BossWellApp;
using BossWellModel;
using System.Web.Mvc;

namespace BossWellWeb.Areas.PublicBusines.Controllers
{
    public class ComClassController : ControllerBase
    {
        private ComClassAPP comclassAPP = new ComClassAPP();

        [HttpGet]
        public ActionResult GetParentListJson()
        {
            return Content(comclassAPP.GetParentTree());
        }

        [HttpGet]
        public ActionResult GetParentList()
        {
            return Content(comclassAPP.GetParentGrid());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeGridJson(string parentId)
        {
            return Content(comclassAPP.GetTreeGridJson(parentId));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            return Content(comclassAPP.GetFormJson(keyValue));
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ComClassEntity comclassEntity, string keyValue)
        {
            comclassAPP.SaveForm(comclassEntity, keyValue);
            return Success("保存成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            comclassAPP.DeleteForm(keyValue);
            return Success("删除成功");
        }

        #region Get Select

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetSelectByParent(string parentId)
        {
            return Content(comclassAPP.GetSelectJsonByParent(parentId));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson()
        {
            return Content(comclassAPP.GetTreeSelectJson(string.Empty));
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetChildTreeSelectJson(string parentId)
        {
            return Content(comclassAPP.GetTreeSelectJson(parentId));
        }

        #endregion Get Select

        #region InIt

        [HttpGet]
        [HandlerAuthorize]
        public ActionResult TabType()
        {
            return View();
        }

        #endregion InIt
    }
}