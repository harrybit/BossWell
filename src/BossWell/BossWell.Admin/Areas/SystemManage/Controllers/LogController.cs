using BossWell.ApiHelp;
using BossWell.Application;
using BossWell.Model;
using BossWell.Model.Basic;
using System.Web.Mvc;

namespace BossWell.Admin.Areas.SystemManage.Controllers
{
    /// <summary>
    /// 日志控制
    /// </summary>
    public class LogController : ControllerBase
    {
        private LogApplication logApp = new LogApplication();
        
        /// <summary>
        /// 视图初始化
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RemoveLog()
        {
            return View();
        }

        /// <summary>
        /// 日志列表
        /// </summary>
        /// <param name="pagination">分页模型</param>
        /// <param name="queryJson">筛选条件</param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        public ActionResult GetGridJson(Pagination pagination, string queryJson)
        {
            var data = new
            {
                rows = logApp.GetLogListByTime(pagination, queryJson),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(ApiHelper.JsonSerial(data));
        }

        /// <summary>
        /// 清理日志
        /// </summary>
        /// <param name="keepTime">时间段</param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        public ActionResult SubmitRemoveLog(string keepTime)
        {
            logApp.DeleteForm(keepTime);
            return Success("清理成功...");
        }
    }
}