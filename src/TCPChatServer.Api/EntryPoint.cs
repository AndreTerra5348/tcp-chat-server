using TCPChatServer.Api.Controllers;
using TCPChatServer.Core.Services;

namespace TCPChatServer.Api;

public class EntryPoint : BackgroundService
{
    private readonly IConnectionService _connectionService;
    private readonly IServiceProvider _serviceProvider;

    public EntryPoint(IConnectionService connectionService,
        IServiceProvider serviceProvider)
    {
        _connectionService = connectionService;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var serviceScope = _serviceProvider.CreateScope();

        var clientController = serviceScope.ServiceProvider.GetService<ClientController>();
        var receivedDataController = serviceScope.ServiceProvider.GetService<ReceivedDataController>();
        var commandController = serviceScope.ServiceProvider.GetService<CommandController>();

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Run(() => _connectionService.AwaitConnection(stoppingToken));
        }
    }
}
