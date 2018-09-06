using BossWellModel;
using BossWellModel.Base;
using BossWellORM;
using IBossWellService;

namespace BossWellService
{
    public class NewsService : ChloeClient, INewsService
    {
        public QueryResponse<NewsEntity> GetPageList(QueryRequest<NewsEntity> request)
        {
            return Query(request);
        }

        public NewsEntity GetFormJson(string sid)
        {
            return Sing<NewsEntity>(t => t.Sid.Equals(sid));
        }

        public NewsEntity SaveFormJson(NewsEntity saveModel)
        {
            return Save(saveModel, "news_");
        }

        public int DeleteForm(string sid)
        {
            return context.Delete<NewsEntity>(t => t.Sid.Equals(sid));
        }
    }
}