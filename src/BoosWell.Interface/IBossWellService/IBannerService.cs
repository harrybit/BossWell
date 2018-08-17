using BossWellModel;
using BossWellModel.Base;
using BossWellModel.BossWellModel;
namespace IBossWellService
{
    public interface IBannerService
    {
        QueryResponse<BannerEntity> GetPageList(QueryRequest<BannerEntity> request);
        BannerEntity GetFormJson(string sid);
        BannerEntity SaveFormJson(BannerEntity saveModel);
        int DeleteForm(string sid);
    }
}
