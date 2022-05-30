using TCPChatServer.Core.Models;

namespace TCPChatServer.Core.Repositories;

public interface IClientRepository : IRepository<Client>
{
    Client Get(Guid id);
    IEnumerable<Client> GetAll();

}