using System.Net.Sockets;
using System.Text;
using TCPChatServer.Core.Events;
using TCPChatServer.Core.Models;
using TCPChatServer.Core.Services;

namespace TCPChatServer.Service;

public class DataService : IDataService
{
    private readonly IClientService _clientService;

    public EventHandler<ReceivedDataEventArgs>? Received { get; set; }

    public DataService(IClientService clientService)
    {
        _clientService = clientService;
    }

    public void Broadcast(Guid senderId, string message)
    {
        var clients = _clientService.GetAll();
        foreach (var client in clients)
        {
            var stream = client.TcpClient.GetStream();
            var bytes = Encoding.UTF8.GetBytes(message);
            stream.Write(bytes, 0, bytes.Length);
        }
    }

    public void Send(Guid senderId, string message)
    {
        var client = _clientService.Get(senderId);
        var stream = client.TcpClient.GetStream();
        var bytes = Encoding.UTF8.GetBytes(message);
        stream.Write(bytes, 0, bytes.Length);
    }

    public void Receive(Guid clientId, TcpClient tcpClient)
    {
        var stream = tcpClient.GetStream();
        var buffer = new byte[1024];
        while (true)
        {
            var length = stream.Read(buffer, 0, buffer.Length);
            if (length == 0)
            {
                break;
            }

            var data = Encoding.UTF8.GetString(buffer, 0, length);
            var handler = Received;
            if (handler != null)
            {
                handler(this, new ReceivedDataEventArgs(new ReceivedData(clientId, data)));
            }
        }
    }
}