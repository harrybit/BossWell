using BossWell.Chloe;
using BossWell.Interface;
using BossWell.Model;
namespace BossWell.Service
{
    /// <summary>
    /// 后台管理员
    /// </summary>
    public class AdminUserService : ChloeProvider, IAdminUserService
    {
        public QueryResponse<AdminUserEntity> GetPageList(QueryRequest<AdminUserEntity> request)
        {
            return Query<AdminUserEntity>(request);
        }

        public AdminUserEntity GetSingle(string sid)
        {
            return QuerySing<AdminUserEntity>(t => t.Sid.Equals(sid));
        }

        public AdminUserEntity SaveFrom(AdminUserEntity saveModel)
        {
            return Save(saveModel,"adminuser_");
        }

        public int DeleteFrom(string sid)
        {
            return _context.Delete<AdminUserEntity>(t => t.Sid.Equals(sid));
        }
    }
}
