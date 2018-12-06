using BossWell.Model;
namespace BossWell.Interface
{
    public interface IClientService
    {
        QueryResponse<ClientEntity> GetPageList(QueryRequest<ClientEntity> request);

        ClientEntity GetSingle(string sid);

        ClientEntity SaveFrom(ClientEntity saveModel);

        int DeleteFrom(string sid);
    }
}
