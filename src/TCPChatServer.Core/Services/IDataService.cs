using System.Net.Sockets;
using TCPChatServer.Core.Events;
using TCPChatServer.Core.Models;

namespace TCPChatServer.Core.Services;

public interface IDataService
{
    EventHandler<ReceivedDataEventArgs>? Received { get; set; }
    void Broadcast(Guid senderId, string message);
    void Send(Guid senderId, string message);
    void Receive(Guid clientId, TcpClient tcpClient);
    Task<ReceivedData> ReceiveAsync(Guid clientId, TcpClient tcpClient);
}