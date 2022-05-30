using TCPChatServer.Core.Models;

namespace TCPChatServer.Core.Services;

public interface IUserService
{
    void Add(User user);
    void Remove(User user);
    User Get(Guid id);
    User Get(string name);
}