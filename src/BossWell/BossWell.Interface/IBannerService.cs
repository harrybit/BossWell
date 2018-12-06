using BossWell.Model;
namespace BossWell.Interface
{
    public interface IBannerService
    {
        QueryResponse<BannerEntity> GetPageList(QueryRequest<BannerEntity> request);

        BannerEntity GetSingle(string sid);

        BannerEntity SaveFrom(BannerEntity saveModel);

        int DeleteFrom(string sid);
    }
}
