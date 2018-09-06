using ApiHelp;
using BossWellApp.Basic;
using BossWellFactory;
using BossWellModel;
using BossWellModel.Base;
using BossWellModel.BossWellModel;
using IBossWellService;
using System.Collections.Generic;

namespace BossWellApp
{
    public class NewsApp
    {
        private INewsService _service = PublicFactory.GetNewsService();
        private IComClassService _comService = SysAutoFactory.GetComClassService();

        public string GetGridJson(Pagination pagination, string keyword)
        {
            List<NewsEntity> list = GetPageList(pagination, keyword).Items;
            var data = new
            {
                rows = list,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return ApiHelper.JsonSerial(data);
        }

        public string GetFormJson(string sid)
        {
            NewsEntity newsEntity = _service.GetFormJson(sid);
            return ApiHelper.JsonSerial(newsEntity);
        }

        public NewsEntity SubmitForm(NewsEntity entity, string sid)
        {
            if (!string.IsNullOrEmpty(entity.ComClassSid))
            {
                ComClassEntity comEntity = _comService.GetFormData(entity.ComClassSid);
                entity.ComClass = (comEntity == null ? string.Empty : comEntity.Title);
            }
            if (!string.IsNullOrEmpty(sid))
            {
                NewsEntity editEntity = _service.GetFormJson(sid);
                if (editEntity != null)
                {
                    entity.Sid = editEntity.Sid;
                    entity.CreateDate = editEntity.CreateDate;
                }
            }

            return _service.SaveFormJson(entity);
        }

        public int DeleteForm(string sid)
        {
            return _service.DeleteForm(sid);
        }

        private QueryResponse<NewsEntity> GetPageList(Pagination pagination, string keyWord, string comclassSid = "")
        {
            QueryRequest<NewsEntity> request = new QueryRequest<NewsEntity>();
            keyWord = string.IsNullOrEmpty(keyWord) ? string.Empty : keyWord;
            request.Page = pagination.page;
            request.PageSize = pagination.rows;
            request.expression = (t => t.Title.Contains(keyWord));

            if (!string.IsNullOrEmpty(comclassSid))
            {
                request.expression = request.expression.And(t => t.ComClassSid.Equals(comclassSid) && t.IsEnable);
            }

            request.Sort = (t => t.CreateDate);
            request.SortTp = "desc";
            QueryResponse<NewsEntity> response = _service.GetPageList(request);
            pagination.records = response.TotalCount;
            return response;
        }

        public QueryResponse<NewsEntity> GetPageList(int page, int pageSize, string comclassSid)
        {
            return GetPageList(new Pagination()
            {
                page = page,
                rows = pageSize
            }, string.Empty, comclassSid);
        }
    }
}