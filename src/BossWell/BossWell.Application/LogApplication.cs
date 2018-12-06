using BossWell.ApiHelp;
using BossWell.Domain;
using BossWell.Interface;
using BossWell.Model;
using BossWell.Model.Admin;
using BossWell.Model.Basic;
using BossWell.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BossWell.Application
{
    public class LogApplication
    {
        ILogService _service = SysAuthFactory.GetLogService();

        /// <summary>
        /// 日志列表
        /// </summary>
        /// <param name="moduleType">菜单类型</param>
        /// <returns></returns>
        public List<LogEntity> GetLogListByTime(Pagination pagination, string queryJson)
        {
            QueryRequest<LogEntity> request = new QueryRequest<LogEntity>();
            LogSearchModel searchModel = new LogSearchModel();
            DateTime logDate = DateTime.Now;

            //筛选条件
            if (!string.IsNullOrEmpty(queryJson))
            {
                searchModel = ApiHelper.JsonDeserial<LogSearchModel>(queryJson);
            }
            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.keyWord))
                {
                    request.Expression = t => (t.Title.Contains(searchModel.keyWord) || t.Source.Contains(searchModel.keyWord));
                }
                if (searchModel.timeType > 0)
                {
                    if (searchModel.timeType == 2) { logDate = logDate.AddDays(-7); }
                    else if (searchModel.timeType == 1) { logDate = (logDate.Year + "-" + logDate.Month + "-" + logDate.Day)._DateTime(); }
                    else if (searchModel.timeType == 3) { logDate = logDate.AddMonths(-1); }
                    else if (searchModel.timeType == 4) { logDate = logDate.AddMonths(-3); }
                    request.Expression = ((request.Expression == null) ? (t => t.CreateDate >= logDate) : request.Expression.And(t => t.CreateDate >= logDate));
                }
            }
            request.Page = pagination.page;
            request.PageSize = pagination.rows;
            request.Sort = "CreateDate desc";
            QueryResponse<LogEntity> response = _service.GetPageList(request);
            pagination.records = response.TotalCount;
            return response.Items.ToList();
        }

        /// <summary>
        /// 添加系统日志
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="source">来源</param>
        /// <param name="logType">日志类型</param>
        /// <param name="content">内容</param>
        /// <param name="iP">IP</param>
        /// <param name="Remark">备注</param>
        public void AddLog(string title, string source, LogEnum logType, string content, string iP = "", string Remark = "")
        {
            LogEntity logEntity = new LogEntity();
            logEntity.IsDelete = false;
            logEntity.Title = title;
            logEntity.Source = source;
            logEntity.LogType = logType;
            logEntity.Content = content;
            logEntity.IP = iP;
            logEntity.Remark = iP;
            logEntity.CreateUser = string.Empty;
            _service.SaveFrom(logEntity);
        }

        /// <summary>
        /// 删除某段时间内日志
        /// </summary>
        /// <param name="keepTime">时间段7:七天,1:一月,3:三月</param>
        /// <returns></returns>
        public bool DeleteForm(string keepTime)
        {
            DateTime logCreateDate = DateTime.MinValue;
            if (keepTime.Equals("7")) { logCreateDate = DateTime.Now.AddDays(-7); }
            else if (keepTime.Equals("1")) { logCreateDate = DateTime.Now.AddMonths(-1); }
            else if (keepTime.Equals("3")) { logCreateDate = DateTime.Now.AddMonths(-3); }
            int result = _service.DeleteFrom(logCreateDate);
            return result < 1 ? false : true;
        }
    }
}
