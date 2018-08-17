using BossWellModel;
using IBossWellService;
using BossWellFactory;
using BossWellModel.Base;
using BossWellModel.BossWellModel;
using System.Collections.Generic;
using ApiHelp;

namespace BossWellApp
{
    public class DeviceVersionApp
    {
        IDeviceVersionService _service = PublicFactory.GetDeviceVersion();

        public string GetGridJson(Pagination pagination, string keyword)
        {
            List<DeviceVersionEntity> list = GetPageList(pagination, keyword);
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
            DeviceVersionEntity cltEntity = _service.GetForm(sid);
            return ApiHelper.JsonSerial(cltEntity);
        }

        public DeviceVersionEntity SubmitForm(DeviceVersionEntity devEntity, string sid)
        {
            if (!string.IsNullOrEmpty(sid))
            {
                DeviceVersionEntity editEntity = _service.GetForm(sid);
                if (editEntity != null)
                {
                    devEntity.Sid = editEntity.Sid;
                    devEntity.CreateDate = editEntity.CreateDate;
                }
            }
            return _service.SaveForm(devEntity);
        }

        public int DeleteForm(string sid)
        {
            return _service.DeleteForm(sid);
        }

        private List<DeviceVersionEntity> GetPageList(Pagination pagination, string keyword)
        {
            keyword = string.IsNullOrEmpty(keyword) ? string.Empty : keyword;
            QueryRequest<DeviceVersionEntity> request = new QueryRequest<DeviceVersionEntity>();
            request.expression = (t => t.Title.Contains(keyword));
            request.Page = pagination.page;
            request.PageSize = pagination.rows;
            request.Sort = (t => t.CreateDate);
            request.SortTp = "desc";
            QueryResponse<DeviceVersionEntity> response = _service.GetPageList(request);
            pagination.records = response.TotalCount;
            return response.Items;
        }
    }
}
