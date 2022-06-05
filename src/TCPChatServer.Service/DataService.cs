using System.Net.Sockets;
using System.Text;
using Microsoft.Extensions.Logging;
using TCPChatServer.Core.Events;
using TCPChatServer.Core.Models;
using TCPChatServer.Core.Services;

namespace TCPChatServer.Service;

public class DataService : IDataService
{
    private readonly IClientService _clientService;
    private readonly ILogger<DataService> _logger;

    public DataService(IClientService clientService, ILogger<DataService> logger)
    {
        _clientService = clientService;
        _logger = logger;
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

    public async Task<byte[]> ReceiveAsync(Client client, CancellationToken ct)
    {
        var stream = client.TcpClient.GetStream();
        var buffer = new byte[1024];
        var length = 0;
        using var ms = new MemoryStream();
        _logger.LogInformation("Waiting for data");
        while ((length = await stream.ReadAsync(buffer, 0, buffer.Length, ct)) > 0)
        {
            ms.Write(buffer, 0, length);
        }
        return ms.ToArray();
    }
}