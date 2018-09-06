using BossWellModel;
using BossWellModel.Base;

namespace IBossWellService
{
    public interface IAdminUserService
    {
        QueryResponse<AdminUserEntity> GetList(QueryRequest<AdminUserEntity> request);

        AdminUserEntity GetFromData(string sid);

        AdminUserEntity GetFormByAccount(string account, string pwd);

        int DeleteForm(string sid);

        void SubmitForm(AdminUserEntity userEntity);

        int ResetPwd(string passWord, string sid);

        int DisEnableAccount(bool isEnable, string sid);
    }
}