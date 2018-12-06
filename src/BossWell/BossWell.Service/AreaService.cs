using BossWell.Chloe;
using BossWell.Interface;
using BossWell.Model;
using Chloe;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BossWell.Service
{
    /// <summary>
    /// 行政区域
    /// </summary>
    public class AreaService : ChloeProvider, IAreaService
    {
        public QueryResponse<AreaEntity> GetPageList(QueryRequest<AreaEntity> request)
        {
            return Query<AreaEntity>(request);
        }

        public AreaEntity GetSingle(string sid)
        {
            return QuerySing<AreaEntity>(t => t.Sid.Equals(sid));
        }

        public AreaEntity SaveFrom(AreaEntity saveModel)
        {
            return Save(saveModel, "area_");
        }

        public List<AreaEntity> GetAreaChildListBySid(string pSid)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select * from Area ");
            sqlBuilder.Append("where FIND_IN_SET(Sid,GetAreaChildList(@Pid)) and Sid != @Pid ");
            DbParam pidParam = new DbParam("@Pid", pSid);
            return _context.SqlQuery<AreaEntity>(sqlBuilder.ToString(), new DbParam[] { pidParam }).ToList();
        }

        public int DeleteFrom(List<string> sid)
        {
            return _context.Delete<AreaEntity>(t => sid.Contains(t.Sid));
        }
    }
}
