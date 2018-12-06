using BossWell.Model;
using System.Collections.Generic;
namespace BossWell.Interface
{
    public interface ISysConfigService
    {
        QueryResponse<SystemConfigEntity> GetPageList(QueryRequest<SystemConfigEntity> request);

        SystemConfigEntity GetSingle(string sid);

        SystemConfigEntity SaveFrom(SystemConfigEntity saveModel);

        List<SystemConfigEntity> GetSysConfigChildListBySid(string pSid);

        int DeleteFrom(List<string> sid);
    }
}
