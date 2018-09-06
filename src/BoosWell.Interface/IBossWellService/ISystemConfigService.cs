using BossWellModel;
using BossWellModel.Base;
using System.Collections.Generic;

namespace IBossWellService
{
    public interface ISystemConfigService
    {
        QueryResponse<SystemConfigEntity> GetPageList(QueryRequest<SystemConfigEntity> request);

        SystemConfigEntity GetForm(string sid);

        SystemConfigEntity SaveForm(SystemConfigEntity entity);

        int DeleteForm(List<string> sid);

        List<string> GetChildNodeList(string parentId);
    }
}