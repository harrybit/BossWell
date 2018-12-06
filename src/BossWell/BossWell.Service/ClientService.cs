using BossWell.Chloe;
using BossWell.Interface;
using BossWell.Model;

namespace BossWell.Service
{
    /// <summary>
    /// 客户会员
    /// </summary>
    public class ClientService : ChloeProvider, IClientService
    {
        public QueryResponse<ClientEntity> GetPageList(QueryRequest<ClientEntity> request)
        {
            return Query<ClientEntity>(request);
        }

        public ClientEntity GetSingle(string sid)
        {
            return QuerySing<ClientEntity>(t => t.Sid.Equals(sid));
        }

        public ClientEntity SaveFrom(ClientEntity saveModel)
        {
            return Save(saveModel,"client_");
        }

        public int DeleteFrom(string sid)
        {
            return _context.Delete<ClientEntity>(t => t.Sid.Equals(sid));
        }
    }
}
