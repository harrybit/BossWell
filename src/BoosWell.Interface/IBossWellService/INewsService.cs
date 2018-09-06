using BossWellModel;
using BossWellModel.Base;

namespace IBossWellService
{
    public interface INewsService
    {
        QueryResponse<NewsEntity> GetPageList(QueryRequest<NewsEntity> request);

        NewsEntity GetFormJson(string sid);

        NewsEntity SaveFormJson(NewsEntity saveModel);

        int DeleteForm(string sid);
    }
}