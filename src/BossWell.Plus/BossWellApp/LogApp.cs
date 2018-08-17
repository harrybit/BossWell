using BossWellFactory;
using BossWellModel;
using IBossWellService;
using System;
using System.Collections.Generic;
using BossWellModel.BossWellModel;
using ApiHelp;
using BossWellApp.Basic;
using BossWellModel.Enum;
using BossWellModel.Base;
using Newtonsoft.Json.Linq;

namespace BossWellApp
{
    public class LogApp
    {
        private readonly ILogService _service = SysAutoFactory.GetLogService();

        public string GetGridJson(Pagination pagination, string queryJson)
        {
            QueryRequest<LogEntity> request = new QueryRequest<LogEntity>();
            request.Page = pagination.page;
            request.PageSize = pagination.rows;
            request.Sort = (t => t.CreateDate);
            request.SortTp = "desc";
            request.expression = (t => true);

            if (!string.IsNullOrEmpty(queryJson) && queryJson.Length > 0)
            {
                JObject jsonObj = JObject.Parse(queryJson);
                string keyWord = jsonObj["keyword"].ToString();
                int timeType = jsonObj["timeType"]._Int();
                if (!string.IsNullOrEmpty(keyWord))
                {
                    request.expression = (t => t.Title.Contains(keyWord));
                }

                if (timeType > 0)
                {
                    DateTime beginDate = DateTime.MinValue;
                    switch (timeType)
                    {
                        case 1:
                            //今天
                            beginDate = DateTime.Now.ToString("yyyy-MM-dd")._DateTime();
                            request.expression = request.expression.And(t => t.CreateDate >= beginDate);
                            break;
                        case 2:
                            //近七天
                            beginDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")._DateTime();
                            request.expression = request.expression.And(t => t.CreateDate >= beginDate);
                            break;
                        case 3:
                            //近一月
                            beginDate = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd")._DateTime();
                            request.expression = request.expression.And(t => t.CreateDate >= beginDate);
                            break;
                        case 4:
                            //近三月
                            beginDate = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd")._DateTime();
                            request.expression = request.expression.And(t => t.CreateDate >= beginDate);
                            break;
                    }
                }
            }

            QueryResponse<LogEntity> response = _service.GetPageList(request);
            pagination.records = response.TotalCount;

            var data = new
            {
                rows = response.Items,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };

            return ApiHelper.JsonSerial(data);
        }

        public int RemoveLog(string keepTime)
        {
            DateTime operateTime = DateTime.MinValue;
            if (keepTime == "7")            //保留近一周
            {
                operateTime = DateTime.Now.AddDays(-7);
            }
            else if (keepTime == "1")       //保留近一个月
            {
                operateTime = DateTime.Now.AddMonths(-1);
            }
            else if (keepTime == "3")       //保留近三个月
            {
                operateTime = DateTime.Now.AddMonths(-3);
            }
            return _service.DeleteForm(operateTime);
        }

        public LogEntity AddSysLog(string title, string source, string content, string result = "")
        {
            OperatorModel adminUserModel = OperatorProvider.Provider.GetCurrent();

            LogEntity logEntity = new LogEntity();
            logEntity.Content = content;
            logEntity.CreateUser = adminUserModel.UserName;
            logEntity.IP = ApiHelper.GetClientIP();
            logEntity.LogType = LogTypeEnum.后台日志;
            logEntity.Remark = "";
            logEntity.Result = result;
            logEntity.Source = source;
            logEntity.Title = title;
            return _service.SaveForm(logEntity);
        }

    }
}
