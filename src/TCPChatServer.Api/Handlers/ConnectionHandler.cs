using TCPChatServer.Api.Controllers;
using TCPChatServer.Core.Handlers;
using TCPChatServer.Core.Models;
using TCPChatServer.Core.Services;

namespace TCPChatServer.Api.Handlers;

public class ConnectionHandler : IConnectionHandler
{
    private readonly IConnectionService _connectionService;
    private readonly ClientController _clientController;
    private readonly UserController _userController;

    public ConnectionHandler(IConnectionService connectionService,
        ClientController clientController,
        UserController userController)
    {
        _connectionService = connectionService;
        _clientController = clientController;
        _userController = userController;
    }

    public async Task<Client> HandleConnectionAsync(CancellationToken stoppingToken)
    {
        var tcpClient = await _connectionService.ListenAsync(stoppingToken);
        var client = _clientController.Create(tcpClient);
        _userController.Create(client.Id);
        return client;
    }
}
