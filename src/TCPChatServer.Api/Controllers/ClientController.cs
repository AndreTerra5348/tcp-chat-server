using System.Net.Sockets;
using TCPChatServer.Core;
using TCPChatServer.Core.Models;
using TCPChatServer.Core.Services;

namespace TCPChatServer.Api.Controllers;

public class ClientController
{
    private readonly IDataService _dataService;
    private readonly IClientService _clientService;
    private readonly IUserService _userService;
    private readonly ILogger<ClientController> _logger;

    public ClientController(IConnectionService connectionService,
        IDataService dataService,
        IClientService clientService,
        IUserService userService,
        ILogger<ClientController> logger)
    {
        _dataService = dataService;
        _clientService = clientService;
        _userService = userService;
        connectionService.ClientConnected += (s, e) => ClientConnected(e.TcpClient);
        _logger = logger;
    }

    public void ClientConnected(TcpClient tcpClient)
    {
        _logger.LogInformation("Client connected");
        var client = new Client(tcpClient, Guid.NewGuid());
        var user = new User(client.Id);
        _clientService.Add(client);
        _userService.Add(user);
        Task.Run(() =>
        {
            while (tcpClient.Connected)
            {
                _dataService.Receive(client.Id, tcpClient);
            }
        });
    }
}