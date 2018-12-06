using BossWell.Model;
namespace BossWell.Interface
{
    public interface IAdminUserService
    {
        QueryResponse<AdminUserEntity> GetPageList(QueryRequest<AdminUserEntity> request);

        AdminUserEntity GetSingle(string sid);

        AdminUserEntity SaveFrom(AdminUserEntity saveModel);

        int DeleteFrom(string sid);
    }
}
