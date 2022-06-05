using TCPChatServer.Core.Handlers;
namespace TCPChatServer.Api;

public class EntryPoint : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<EntryPoint> _logger;

    public EntryPoint(IServiceProvider serviceProvider, ILogger<EntryPoint> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var serviceScope = _serviceProvider.CreateScope();

        var connectionHandler = serviceScope.ServiceProvider.GetService<IConnectionHandler>();
        if (connectionHandler == null)
        {
            _logger.LogError("ConnectionHandler is null");
            throw new InvalidOperationException("Could not find ConnectionHandler");
        }

        var clientHandler = serviceScope.ServiceProvider.GetService<IClientHandler>();
        if (clientHandler == null)
        {
            _logger.LogError("ClientHandler is null");
            throw new InvalidOperationException("Could not find ClientHandler");
        }

        while (!stoppingToken.IsCancellationRequested)
        {
            var client = await connectionHandler.HandleConnectionAsync(stoppingToken);

            await Task.Factory.StartNew(async () => await clientHandler.HandleClientAsync(client, stoppingToken),
                stoppingToken, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }
    }
}
