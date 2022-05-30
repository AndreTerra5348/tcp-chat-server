using TCPChatServer.Core.Models;

namespace TCPChatServer.Core.Services;

public interface IClientService
{
    void Add(Client client);
    void Remove(Client client);
    Client Get(Guid id);
    IEnumerable<Client> GetAll();
}