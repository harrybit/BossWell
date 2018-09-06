using BossWellModel;
using BossWellModel.Base;
using BossWellORM;
using IBossWellService;

namespace BossWellService
{
    public class BannerService : ChloeClient, IBannerService
    {
        public QueryResponse<BannerEntity> GetPageList(QueryRequest<BannerEntity> request)
        {
            return Query(request);
        }

        public BannerEntity GetFormJson(string sid)
        {
            return Sing<BannerEntity>(t => t.Sid.Equals(sid));
        }

        public BannerEntity SaveFormJson(BannerEntity saveModel)
        {
            return Save(saveModel, "banner_");
        }

        public int DeleteForm(string sid)
        {
            return context.Delete<BannerEntity>(t => t.Sid.Equals(sid));
        }
    }
}