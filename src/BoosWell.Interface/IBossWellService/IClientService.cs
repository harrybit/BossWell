using BossWellModel;
using BossWellModel.Base;

namespace IBossWellService
{
    public interface IClientService
    {
        QueryResponse<ClientEntity> GetPageList(QueryRequest<ClientEntity> request);

        ClientEntity GetFormJson(string sid);

        ClientEntity SaveFormJson(ClientEntity saveModel);

        int DeleteForm(string sid);

        ClientEntity GetEntityByToken(string token);

        ClientEntity GetEntityByAccount(string account);

        ClientEntity GetLoginEntity(string accountNo, string passWord);

        int ModifyCltToken(string account, string token);
    }
}