using TCPChatServer.Core.Models;

namespace TCPChatServer.Core.Handlers;

public interface IClientHandler
{
    Task HandleClientAsync(Client client, CancellationToken stoppingToken);
}
