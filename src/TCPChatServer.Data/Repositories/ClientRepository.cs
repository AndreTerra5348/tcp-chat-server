using TCPChatServer.Core.Models;
using TCPChatServer.Core.Repositories;

namespace TCPChatServer.Data.Repositories;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(TCPChatServerContext context) : base(context)
    {
    }

    public Client Get(Guid id)
    {
        return Context.Clients.First(c => c.Id == id);
    }

    public IEnumerable<Client> GetAll()
    {
        return Context.Clients;
    }
}