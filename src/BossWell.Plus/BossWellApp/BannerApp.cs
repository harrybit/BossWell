using BossWellModel;
using BossWellModel.Base;
using BossWellModel.BossWellModel;
using BossWellFactory;
using IBossWellService;
using System.Collections.Generic;
using ApiHelp;
using BossWellApp.Basic;

namespace BossWellApp
{
    public class BannerApp
    {
        IBannerService _service = PublicFactory.GetBannerService();
        IComClassService _comService = SysAutoFactory.GetComClassService();
        public string GetGridJson(Pagination pagination, string keyword)
        {
            List<BannerEntity> list = GetPageList(pagination, keyword).Items;
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
            BannerEntity bannerEntity = _service.GetFormJson(sid);
            return ApiHelper.JsonSerial(bannerEntity);
        }

        public BannerEntity SubmitForm(BannerEntity entity, string sid)
        {
            if (!string.IsNullOrEmpty(entity.ComClassSid))
            {
                ComClassEntity comEntity = _comService.GetFormData(entity.ComClassSid);
                entity.ComClass = (comEntity == null ? string.Empty : comEntity.Title);
            }
            if (!string.IsNullOrEmpty(sid))
            {
                BannerEntity editEntity = _service.GetFormJson(sid);
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

        private QueryResponse<BannerEntity> GetPageList(Pagination pagination, string keyWord, string comClassSid = "")
        {
            QueryRequest<BannerEntity> request = new QueryRequest<BannerEntity>();
            keyWord = string.IsNullOrEmpty(keyWord) ? string.Empty : keyWord;
            request.Page = pagination.page;
            request.PageSize = pagination.rows;
            request.expression = (t => t.Title.Contains(keyWord));

            if (!string.IsNullOrEmpty(comClassSid))
            {
                request.expression = request.expression.And(c => c.ComClassSid.Equals(comClassSid) && c.IsEnable);
            }

            request.Sort = (t => t.CreateDate);
            request.SortTp = "desc";
            QueryResponse<BannerEntity> response = _service.GetPageList(request);
            pagination.records = response.TotalCount;
            return response;
        }

        public QueryResponse<BannerEntity> GetPageList(int page, int pageSize, string comClassSid)
        {
            return GetPageList(new Pagination()
            {
                page = page,
                rows = pageSize
            }, string.Empty, comClassSid);
        }
    }
}
