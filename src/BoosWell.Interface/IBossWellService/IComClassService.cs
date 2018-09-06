using BossWellModel;
using BossWellModel.Base;
using System.Collections.Generic;

namespace IBossWellService
{
    public interface IComClassService
    {
        QueryResponse<ComClassEntity> GetPageList(QueryRequest<ComClassEntity> request);

        ComClassEntity GetFormData(string sid);

        List<string> GetChildNodeList(string parentId);

        ComClassEntity SaveForm(ComClassEntity saveModel);

        int DeleteForm(List<string> sidList);

        List<ComClassEntity> GetAllChildByParentId(string parentId);
    }
}