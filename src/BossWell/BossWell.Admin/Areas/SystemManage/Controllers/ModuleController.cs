using BossWell.ApiHelp;
using BossWell.Application;
using BossWell.Model;
using BossWell.Model.Basic;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace BossWell.Admin.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 菜单控制
    /// </summary>
    public class ModuleController : ControllerBase
    {
        private ModuleApplication moduleApp = new ModuleApplication();

        #region 菜单

        /// <summary>
        /// 后台树菜单列表
        /// </summary>
        /// <param name="keyword">模糊查询</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        public ActionResult GetTreeModuleList(string keyword)
        {
            List<ModuleEntity> moduleList = moduleApp.GetAllModuleListByType(Model.Enum.ModuleEnum.模块, keyword);

            List<TreeGridModel> resultList = new List<TreeGridModel>();
            moduleList.ForEach(delegate (ModuleEntity item)
            {
                bool isChild = moduleList.Where(t => t.ParentId.Equals(item.Sid)).Count() > 0 ? true : false;
                resultList.Add(new TreeGridModel()
                {
                    id = item.Sid,
                    isLeaf = isChild,
                    parentId = item.ParentId,
                    expanded = isChild,
                    entityJson = ApiHelper.JsonSerial(item)
                });
            });

            return Content(resultList.TreeGridJson());
        }

        /// <summary>
        /// 菜单树下拉集合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetSelectTreeList()
        {
            List<ModuleEntity> moduleList = moduleApp.GetAllModuleListByType(Model.Enum.ModuleEnum.模块, string.Empty);

            List<TreeSelectModel> selectTreeList = moduleList.Select(t => new TreeSelectModel()
            {
                id = t.Sid,
                text = t.FullName,
                parentId = t.ParentId
            }).ToList();
            return Content(selectTreeList.TreeSelectJson());
        }

        /// <summary>
        /// 查询单条表单
        /// </summary>
        /// <param name="keyValue">标识</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            return Content(ApiHelper.JsonSerial(moduleApp.GetEntityBySid(keyValue)));
        }

        /// <summary>
        /// 保存菜单信息
        /// </summary>
        /// <param name="moduleEntity">菜单模型</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ModuleEntity moduleEntity)
        {
            bool result = moduleApp.SubmitModule(moduleEntity);

            if (result) { return Success("保存成功。。。"); }

            return Error("保存失败。。。");
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="keyValue">标识</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            bool result = moduleApp.DeleteForm(keyValue);

            if (result) { return Success("删除成功。。。"); }

            return Error("删除失败。。。");
        }

        #endregion

        #region 按钮

        /// <summary>
        /// 按钮列表初始化
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BtnList()
        {
            return View();
        }
        /// <summary>
        /// 按钮表单初始化
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BtnForm()
        {
            return View();
        }

        /// <summary>
        /// 按钮列表
        /// </summary>
        /// <param name="moduleId">菜单Sid</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetModuleBtnTreeList(string moduleId)
        {
            List<TreeGridModel> list = moduleApp.GetModuleChildList(moduleId).Select(t => new TreeGridModel() { id = t.Sid, text = t.FullName, parentId = "0", isLeaf = false, expanded = false, entityJson = ApiHelper.JsonSerial(t) }).ToList();
            return Content(list.TreeGridJson());
        }

        /// <summary>
        /// 初始化克隆按钮视图
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CloneButton()
        {
            return View();
        }

        /// <summary>
        /// 克隆菜单树列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetCloneBtnTreeList()
        {
            List<TreeViewModel> list = moduleApp.GetAllModuleListByType(Model.Enum.ModuleEnum.未知, string.Empty).Select(t => new TreeViewModel()
            {
                id = t.Sid,
                text = t.FullName,
                value = t.Sid,
                parentId = t.ParentId,
                isexpand = true,
                complete = true,
                hasChildren = true,
                showcheck = (t.Type == Model.Enum.ModuleEnum.按钮 ? true : false),
                img = string.Empty
            }).ToList();
            return Content(list.TreeViewJson());
        }

        /// <summary>
        /// 克隆菜单按钮
        /// </summary>
        /// <param name="moduleId">菜单Sid</param>
        /// <param name="buttonIds">克隆按钮列表</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        public ActionResult SubmitCloneBtn(string moduleId, string buttonIds)
        {
            buttonIds = buttonIds.Replace("-", "_");
            bool result = moduleApp.CloneModuleButton(moduleId, buttonIds);
            if (result) { return Success("克隆成功。。。"); }

            return Error("克隆失败。。。");
        }

        #endregion


    }
}