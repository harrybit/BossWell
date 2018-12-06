using BossWell.Chloe;
using BossWell.Interface;
using BossWell.Model;
using Chloe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BossWell.Service
{
    /// <summary>
    /// 综合分类
    /// </summary>
    public class ComClassService : ChloeProvider, IComClassService
    {
        public QueryResponse<ComClassEntity> GetPageList(QueryRequest<ComClassEntity> request)
        {
            return Query<ComClassEntity>(request);
        }

        public ComClassEntity GetSingle(string sid)
        {
            return QuerySing<ComClassEntity>(t => t.Sid.Equals(sid));
        }

        public ComClassEntity SaveFrom(ComClassEntity saveModel)
        {
            return Save(saveModel, "comclass_");
        }

        public List<ComClassEntity> GetComClassChildListBySid(string pSid)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select * from ComClass ");
            sqlBuilder.Append("where FIND_IN_SET(Sid,GetComClassChildIist(@Pid)) and Sid != @Pid ");
            sqlBuilder.Append("ORDER BY Sort asc ");
            DbParam pidParam = new DbParam("@Pid", pSid);
            return _context.SqlQuery<ComClassEntity>(sqlBuilder.ToString(), new DbParam[] { pidParam }).ToList();
        }

        public int DeleteFrom(List<string> sid)
        {
            return _context.Delete<ComClassEntity>(t => sid.Contains(t.Sid));
        }
    }
}
