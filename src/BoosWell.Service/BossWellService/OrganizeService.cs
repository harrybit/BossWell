using BossWellORM;
using IBossWellService;
using BossWellModel;
using BossWellModel.Base;
using System.Collections.Generic;

namespace BossWellService
{
    public class OrganizeService : ChloeClient, IOrganizeService
    {
        public QueryResponse<OrganizeEntity> GetPageList(QueryRequest<OrganizeEntity> request)
        {
            return Query(request);
        }
        public OrganizeEntity GetFormData(string sid)
        {
            return context.Query<OrganizeEntity>().Where(t => t.Sid.Equals(sid)).FirstOrDefault();
        }
        public List<string> GetChildNodeList(string parentId)
        {
            return context.Query<OrganizeEntity>().Where(t => t.ParentId.Equals(parentId)).Select(t => t.Sid).ToList();
        }
        public OrganizeEntity SaveForm(OrganizeEntity saveModel)
        {
            return Save<OrganizeEntity>(saveModel, "organize_");
        }
        public int DeleteForm(List<string> sidList)
        {
            return context.Delete<OrganizeEntity>(t => sidList.Contains(t.Sid));
        }

    }
}
