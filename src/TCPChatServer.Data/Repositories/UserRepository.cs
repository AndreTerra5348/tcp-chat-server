using TCPChatServer.Core.Models;
using TCPChatServer.Core.Repositories;

namespace TCPChatServer.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(TCPChatServerContext context) : base(context)
    {
    }
    public User Get(Guid id)
    {
        if (Context.Users.Any(x => x.ClientId == id))
        {
            return Context.Users.First(x => x.ClientId == id);
        }
        throw new Exception("User not found");
    }

    public User Get(string name)
    {
        if (Context.Users.Any(x => x.Name == name))
        {
            return Context.Users.First(x => x.Name == name);
        }
        throw new Exception("User not found");
    }
}