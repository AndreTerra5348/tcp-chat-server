using System.Net.Sockets;
using TCPChatServer.Core.Events;
using TCPChatServer.Core.Models;

namespace TCPChatServer.Core.Services;

public interface IDataService
{
    void Broadcast(Guid senderId, string message);
    void Send(Guid senderId, string message);
    Task<byte[]> ReceiveAsync(Client client, CancellationToken ct);

}