using TCPChatServer.Core;
using TCPChatServer.Core.Repositories;
using TCPChatServer.Data.Repositories;

namespace TCPChatServer.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly TCPChatServerContext _context;

    private UserRepository? _userRepository;
    private ClientRepository? _clientRepository;

    public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_context));
    public IClientRepository ClientRepository => _clientRepository ?? (_clientRepository = new ClientRepository(_context));

    public UnitOfWork(TCPChatServerContext context)
    {
        _context = context;
    }

    public void Commit()
    {
    }
}