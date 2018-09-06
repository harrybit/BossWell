using BossWellModel;
using BossWellModel.Base;
using BossWellORM;
using Chloe;
using IBossWellService;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BossWellService
{
    public class ComClassService : ChloeClient, IComClassService
    {
        public QueryResponse<ComClassEntity> GetPageList(QueryRequest<ComClassEntity> request)
        {
            return Query(request);
        }

        public ComClassEntity GetFormData(string sid)
        {
            return context.Query<ComClassEntity>().Where(t => t.Sid.Equals(sid)).FirstOrDefault();
        }

        public List<string> GetChildNodeList(string parentId)
        {
            return context.Query<ComClassEntity>().Where(t => t.ParentId.Equals(parentId)).Select(t => t.Sid).ToList();
        }

        public ComClassEntity SaveForm(ComClassEntity saveModel)
        {
            return Save<ComClassEntity>(saveModel, "comclass_");
        }

        public int DeleteForm(List<string> sidList)
        {
            return context.Delete<ComClassEntity>(t => sidList.Contains(t.Sid));
        }

        public List<ComClassEntity> GetAllChildByParentId(string parentId)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select * from comclass ");
            sqlBuilder.Append("where FIND_IN_SET(Sid,getChildList(@Pid)) ");
            sqlBuilder.Append("and Sid != @Pid ");
            sqlBuilder.Append("order by Sort");
            DbParam paramPid = new DbParam("@Pid", parentId);
            return context.SqlQuery<ComClassEntity>(sqlBuilder.ToString(), new DbParam[] { paramPid }).ToList();
        }
    }
}