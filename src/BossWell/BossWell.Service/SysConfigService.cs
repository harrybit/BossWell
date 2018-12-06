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
    /// 参数配置
    /// </summary>
    public class SysConfigService : ChloeProvider, ISysConfigService
    {
        public QueryResponse<SystemConfigEntity> GetPageList(QueryRequest<SystemConfigEntity> request)
        {
            return Query<SystemConfigEntity>(request);
        }

        public SystemConfigEntity GetSingle(string sid)
        {
            return QuerySing<SystemConfigEntity>(t => t.Sid.Equals(sid));
        }

        public SystemConfigEntity SaveFrom(SystemConfigEntity saveModel)
        {
            return Save(saveModel, "sysConfig_");
        }

        public List<SystemConfigEntity> GetSysConfigChildListBySid(string pSid)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select * from SystemConfig ");
            sqlBuilder.Append("where FIND_IN_SET(Sid,GetSysCfgChildList(@Pid)) and Sid != @Pid ");
            DbParam pidParam = new DbParam("@Pid", pSid);
            return _context.SqlQuery<SystemConfigEntity>(sqlBuilder.ToString(), new DbParam[] { pidParam }).ToList();
        }

        public int DeleteFrom(List<string> sid)
        {
            return _context.Delete<SystemConfigEntity>(t => sid.Contains(t.Sid));
        }
    }
}
