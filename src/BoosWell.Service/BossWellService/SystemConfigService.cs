using BossWellModel;
using BossWellModel.Base;
using BossWellORM;
using IBossWellService;
using System.Collections.Generic;

namespace BossWellService
{
    public class SystemConfigService : ChloeClient, ISystemConfigService
    {
        public QueryResponse<SystemConfigEntity> GetPageList(QueryRequest<SystemConfigEntity> request)
        {
            return Query(request);
        }

        public SystemConfigEntity GetForm(string sid)
        {
            return Sing<SystemConfigEntity>(t => t.Sid.Equals(sid));
        }

        public SystemConfigEntity SaveForm(SystemConfigEntity entity)
        {
            return Save(entity, "sysConfig_");
        }

        public int DeleteForm(List<string> sid)
        {
            return context.Delete<SystemConfigEntity>(t => sid.Contains(t.Sid));
        }

        public List<string> GetChildNodeList(string parentId)
        {
            return context.Query<SystemConfigEntity>().Where(t => t.ParentId.Equals(parentId)).Select(t => t.Sid).ToList();
        }
    }
}