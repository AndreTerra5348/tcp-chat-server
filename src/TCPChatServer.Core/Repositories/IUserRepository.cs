using TCPChatServer.Core.Models;

namespace TCPChatServer.Core.Repositories;

public interface IUserRepository : IRepository<User>
{
    User Get(Guid id);
    User Get(string name);
}
