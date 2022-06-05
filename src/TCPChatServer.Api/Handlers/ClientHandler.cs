using TCPChatServer.Api.Controllers;
using TCPChatServer.Core.Handlers;
using TCPChatServer.Core.Models;
using TCPChatServer.Core.Services;

namespace TCPChatServer.Api.Handlers;

public class ClientHandler : IClientHandler
{
    private readonly IDataService _dataService;
    private readonly ReceivedDataController _receivedDataController;
    private readonly CommandController _commandController;

    public ClientHandler(IDataService dataService,
            ReceivedDataController receivedDataController,
            CommandController commandController)
    {
        _dataService = dataService;
        _receivedDataController = receivedDataController;
        _commandController = commandController;
    }

    public async Task HandleClientAsync(Client client, CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var data = await _dataService.ReceiveAsync(client, stoppingToken);
            var receivedData = _receivedDataController.Create(client.Id, data);
            _commandController.Execute(receivedData);
        }
    }
}