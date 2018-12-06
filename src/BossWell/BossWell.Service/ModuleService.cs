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
    /// 后台菜单
    /// </summary>
    public class ModuleService : ChloeProvider, IModuleService
    {
        public QueryResponse<ModuleEntity> GetPageList(QueryRequest<ModuleEntity> request)
        {
            return Query<ModuleEntity>(request);
        }

        public ModuleEntity GetSingle(string sid)
        {
            return QuerySing<ModuleEntity>(t => t.Sid.Equals(sid));
        }

        public ModuleEntity SaveFrom(ModuleEntity saveModel)
        {
            return Save(saveModel, "module_");
        }

        public List<ModuleEntity> GetModuleChildListBySid(string pSid)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select * from module ");
            sqlBuilder.Append("where FIND_IN_SET(Sid,GetModuleChildList(@Pid)) and Sid != @Pid ");
            DbParam pidParam = new DbParam("@Pid", pSid);
            return _context.SqlQuery<ModuleEntity>(sqlBuilder.ToString(),new DbParam[] { pidParam}).ToList();
        }

        public int DeleteFrom(List<string> sid)
        {
            return _context.Delete<ModuleEntity>(t => sid.Contains(t.Sid));
        }

        public int SaveBatch(List<ModuleEntity> list)
        {
            try
            {
                _context.Session.BeginTransaction();
                _context.InsertRange(list);
                _context.Session.CommitTransaction();
            }
            catch (Exception ex)
            {
                return -1;
            }
           
            return list.Count;
        }
    }
}
