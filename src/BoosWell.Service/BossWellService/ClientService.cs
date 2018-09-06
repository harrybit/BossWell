using BossWellModel;
using BossWellModel.Base;
using BossWellORM;
using IBossWellService;

namespace BossWellService
{
    public class ClientService : ChloeClient, IClientService
    {
        public QueryResponse<ClientEntity> GetPageList(QueryRequest<ClientEntity> request)
        {
            return Query(request);
        }

        public ClientEntity GetFormJson(string sid)
        {
            return Sing<ClientEntity>(t => t.Sid.Equals(sid));
        }

        public ClientEntity SaveFormJson(ClientEntity saveModel)
        {
            return Save(saveModel, "client_");
        }

        public int DeleteForm(string sid)
        {
            return context.Delete<ClientEntity>(t => t.Sid.Equals(sid));
        }

        public ClientEntity GetEntityByToken(string token)
        {
            return Sing<ClientEntity>(t => t.Token.Equals(token));
        }

        public ClientEntity GetEntityByAccount(string account)
        {
            return context.Query<ClientEntity>().Where(t => t.AccountNo.Equals(account) ||
            t.Mobile.Equals(account) || t.Email.Equals(account)).FirstOrDefault();
        }

        public ClientEntity GetLoginEntity(string accountNo, string passWord)
        {
            return context.Query<ClientEntity>().Where(t => (t.AccountNo.Equals(accountNo) ||
            t.Mobile.Equals(accountNo) || t.Email.Equals(accountNo)) && t.PassWord.Equals(passWord)).FirstOrDefault();
        }

        public int ModifyCltToken(string account, string token)
        {
            return context.Update<ClientEntity>(t => t.AccountNo.Equals(account), c => new ClientEntity { Token = token });
        }
    }
}