using System.Net.Sockets;
using TCPChatServer.Core.Events;

namespace TCPChatServer.Core.Services;

public interface IConnectionService
{
    Task<TcpClient> ListenAsync(CancellationToken ct);
}