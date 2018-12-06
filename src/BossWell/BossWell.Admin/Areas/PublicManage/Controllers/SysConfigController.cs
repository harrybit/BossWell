using BossWell.ApiHelp;
using BossWell.Application;
using BossWell.Model;
using BossWell.Model.Basic;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace BossWell.Admin.Areas.PublicManage.Controllers
{
    public class SysConfigController : ControllerBase
    {
        private SysConfigApplication sysApp = new SysConfigApplication();
        
        /// <summary>
        /// 后台树参数配置列表
        /// </summary>
        /// <param name="keyword">模糊查询</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        public ActionResult GetTreeSysConfigList(string keyword)
        {
            List<SystemConfigEntity> moduleList = sysApp.GetAllSysConfigList(keyword);

            List<TreeGridModel> resultList = new List<TreeGridModel>();
            moduleList.ForEach(delegate (SystemConfigEntity item)
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
        /// 参数配置下拉树集合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetSelectTreeList()
        {
            List<SystemConfigEntity> moduleList = sysApp.GetAllSysConfigList(string.Empty);

            List<TreeSelectModel> selectTreeList = moduleList.Select(t => new TreeSelectModel()
            {
                id = t.Sid,
                text = t.Title,
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
            return Content(ApiHelper.JsonSerial(sysApp.GetEntityBySid(keyValue)));
        }

        /// <summary>
        /// 保存参数配置信息
        /// </summary>
        /// <param name="comEntity">分类模型</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(SystemConfigEntity sysEntity)
        {
            bool result = sysApp.SubmitModule(sysEntity);

            if (result) { return Success("保存成功。。。"); }

            return Error("保存失败。。。");
        }

        /// <summary>
        /// 删除参数配置
        /// </summary>
        /// <param name="keyValue">标识</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            bool result = sysApp.DeleteForm(keyValue);

            if (result) { return Success("删除成功。。。"); }

            return Error("删除失败。。。");
        }
    }
}