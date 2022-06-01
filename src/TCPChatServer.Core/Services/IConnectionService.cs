using TCPChatServer.Core.Events;

namespace TCPChatServer.Core.Services;

public interface IConnectionService
{
    EventHandler<ClientEventArgs>? ClientConnected { get; set; }
    void AwaitConnection(CancellationToken ct);
}