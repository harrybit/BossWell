using BossWell.Chloe;
using BossWell.Interface;
using BossWell.Model;

namespace BossWell.Service
{
    /// <summary>
    /// 轮播图
    /// </summary>
    public class BannerService : ChloeProvider, IBannerService
    {
        public QueryResponse<BannerEntity> GetPageList(QueryRequest<BannerEntity> request)
        {
            return Query<BannerEntity>(request);
        }

        public BannerEntity GetSingle(string sid)
        {
            return QuerySing<BannerEntity>(t => t.Sid.Equals(sid));
        }

        public BannerEntity SaveFrom(BannerEntity saveModel)
        {
            return Save(saveModel,"banner_");
        }

        public int DeleteFrom(string sid)
        {
            return _context.Delete<BannerEntity>(t => t.Sid.Equals(sid));
        }
    }
}
