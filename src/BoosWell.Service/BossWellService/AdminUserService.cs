using BossWellModel;
using BossWellModel.Base;
using BossWellORM;
using IBossWellService;

namespace BossWellService
{
    public class AdminUserService : ChloeClient, IAdminUserService
    {
        public QueryResponse<AdminUserEntity> GetList(QueryRequest<AdminUserEntity> request)
        {
            return Query(request);
        }

        public AdminUserEntity GetFromData(string sid)
        {
            return context.Query<AdminUserEntity>().Where(t => t.Sid.Equals(sid)).FirstOrDefault();
        }

        public AdminUserEntity GetFormByAccount(string account, string pwd)
        {
            return context.Query<AdminUserEntity>().Where(t => t.Account.Equals(account) && t.PassWord.Equals(pwd)).FirstOrDefault();
        }

        public int DeleteForm(string sid)
        {
            return context.Delete<AdminUserEntity>(t => t.Sid.Equals(sid));
        }

        public void SubmitForm(AdminUserEntity userEntity)
        {
            Save<AdminUserEntity>(userEntity, "adminuser_");
        }

        public int ResetPwd(string passWord, string sid)
        {
            return context.Update<AdminUserEntity>(t => t.Sid.Equals(sid), c => new AdminUserEntity() { PassWord = passWord });
        }

        public int DisEnableAccount(bool isEnable, string sid)
        {
            return context.Update<AdminUserEntity>(t => t.Sid.Equals(sid), c => new AdminUserEntity() { IsEnable = isEnable });
        }
    }
}