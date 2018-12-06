using BossWell.Model;
using System.Collections.Generic;
namespace BossWell.Interface
{
    public interface IComClassService
    {
        QueryResponse<ComClassEntity> GetPageList(QueryRequest<ComClassEntity> request);

        ComClassEntity GetSingle(string sid);

        ComClassEntity SaveFrom(ComClassEntity saveModel);

        List<ComClassEntity> GetComClassChildListBySid(string pSid);

        int DeleteFrom(List<string> sid);
    }
}
