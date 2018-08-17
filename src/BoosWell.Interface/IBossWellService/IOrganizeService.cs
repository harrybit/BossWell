using BossWellModel;
using BossWellModel.Base;
using System.Collections.Generic;
namespace IBossWellService
{
    public interface IOrganizeService
    {
        QueryResponse<OrganizeEntity> GetPageList(QueryRequest<OrganizeEntity> request);
        OrganizeEntity GetFormData(string sid);
        List<string> GetChildNodeList(string parentId);
        OrganizeEntity SaveForm(OrganizeEntity saveModel);
        int DeleteForm(List<string> sidList);
    }
}
