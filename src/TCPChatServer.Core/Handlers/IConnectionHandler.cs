using TCPChatServer.Core.Models;

namespace TCPChatServer.Core.Handlers;

public interface IConnectionHandler
{
    Task<Client> HandleConnectionAsync(CancellationToken stoppingToken);
}
