using BossWell.Model;
using System.Collections.Generic;
namespace BossWell.Interface
{
    public interface IAreaService
    {
        QueryResponse<AreaEntity> GetPageList(QueryRequest<AreaEntity> request);

        AreaEntity GetSingle(string sid);

        AreaEntity SaveFrom(AreaEntity saveModel);

        List<AreaEntity> GetAreaChildListBySid(string pSid);

        int DeleteFrom(List<string> sid);
    }
}
