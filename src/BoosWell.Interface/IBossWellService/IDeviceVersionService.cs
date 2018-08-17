using BossWellModel;
using BossWellModel.Base;
namespace IBossWellService
{
    public interface IDeviceVersionService
    {
        QueryResponse<DeviceVersionEntity> GetPageList(QueryRequest<DeviceVersionEntity> request);
        DeviceVersionEntity GetForm(string sid);
        DeviceVersionEntity SaveForm(DeviceVersionEntity saveModel);
        int DeleteForm(string sid);
    }
}
