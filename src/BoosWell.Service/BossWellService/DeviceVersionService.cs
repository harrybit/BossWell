using BossWellModel;
using BossWellModel.Base;
using BossWellORM;
using IBossWellService;

namespace BossWellService
{
    public class DeviceVersionService : ChloeClient, IDeviceVersionService
    {
        public QueryResponse<DeviceVersionEntity> GetPageList(QueryRequest<DeviceVersionEntity> request)
        {
            return Query(request);
        }

        public DeviceVersionEntity GetForm(string sid)
        {
            return Sing<DeviceVersionEntity>(t => t.Sid.Equals(sid));
        }

        public DeviceVersionEntity SaveForm(DeviceVersionEntity saveModel)
        {
            return Save(saveModel, "dversion_");
        }

        public int DeleteForm(string sid)
        {
            return context.Delete<DeviceVersionEntity>(t => t.Sid.Equals(sid));
        }
    }
}