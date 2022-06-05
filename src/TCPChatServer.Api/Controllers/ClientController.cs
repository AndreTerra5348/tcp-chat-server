using System.Net.Sockets;
using TCPChatServer.Core;
using TCPChatServer.Core.Models;
using TCPChatServer.Core.Services;

namespace TCPChatServer.Api.Controllers;

public class ClientController
{
    private readonly IClientService _clientService;
    private readonly ILogger<ClientController> _logger;

    public ClientController(IClientService clientService,
        ILogger<ClientController> logger)
    {
        _clientService = clientService;
        _logger = logger;
    }

    public Client Create(TcpClient tcpClient)
    {
        _logger.LogInformation("Client created");
        var client = new Client(tcpClient, Guid.NewGuid());
        _clientService.Add(client);
        return client;
    }
}