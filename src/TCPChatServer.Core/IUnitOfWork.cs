using TCPChatServer.Core.Repositories;

namespace TCPChatServer.Core;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IClientRepository ClientRepository { get; }

    void Commit();
}