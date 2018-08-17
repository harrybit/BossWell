using BossWellORM;
using IBossWellService;
using BossWellModel;
using BossWellModel.Base;
using System.Collections.Generic;
using System.Threading;

namespace BossWellService
{
    public class RoleService : ChloeClient, IRoleService
    {
        public QueryResponse<RoleEntity> GetPageList(QueryRequest<RoleEntity> request)
        {
            return Query<RoleEntity>(request);
        }
        public RoleEntity GetFormData(string Sid)
        {
            return context.Query<RoleEntity>().Where(t => t.Sid.Equals(Sid)).FirstOrDefault();
        }
        public void SubmitForm(RoleEntity roleEntity, List<RoleAuthorizeEntity> authorList)
        {
            context.Session.BeginTransaction();

            RoleEntity saveEntity = Save(roleEntity,"role_");//Save Role
            context.Delete<RoleAuthorizeEntity>(t => t.RoleId.Equals(saveEntity.Sid));//Delete Author
            
            for (int i=0;i<authorList.Count;i++)
            {
                Thread.Sleep(100);
                RoleAuthorizeEntity authorItem = authorList[i];
                authorItem.RoleId = saveEntity.Sid;
                authorItem.RoleType = saveEntity.Category;
                Save(authorItem, "roleauthorize_");
            }

            context.Session.CommitTransaction();
        }
        public int Delete(string sid)
        {
            context.Session.BeginTransaction();
            int deltCount = 0;

            deltCount = context.Delete<RoleEntity>(t => t.Sid.Equals(sid));
            context.Delete<RoleAuthorizeEntity>(t => t.RoleId.Equals(sid));

            context.Session.CommitTransaction();
            return deltCount;
        }

    }
}
