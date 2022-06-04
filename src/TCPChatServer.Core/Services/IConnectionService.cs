using System.Net.Sockets;
using TCPChatServer.Core.Events;

namespace TCPChatServer.Core.Services;

public interface IConnectionService
{
    EventHandler<ClientEventArgs>? ClientConnected { get; set; }
    void Listen(CancellationToken ct);
    Task<TcpClient> ListenAsync(CancellationToken ct);
}