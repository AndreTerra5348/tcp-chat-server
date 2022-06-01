using System.Net.Sockets;
using TCPChatServer.Core.Events;
using TCPChatServer.Core.Providers;
using TCPChatServer.Core.Services;
using Microsoft.Extensions.Logging;

namespace TCPChatServer.Service;

public class ConnectionService : IConnectionService
{
    private readonly TcpListener _listener;
    private readonly ILogger<ConnectionService> _logger;

    public EventHandler<ClientEventArgs>? ClientConnected { get; set; }

    public ConnectionService(ITCPListenerProvider tcpListenerProvider, ILogger<ConnectionService> logger)
    {
        _listener = tcpListenerProvider.CreateTcpListener();
        _listener.Start();
        _logger = logger;
        _logger.LogInformation("Server started");
    }


    public void AwaitConnection(CancellationToken ct)
    {
        using (ct.Register(() => _listener.Stop()))
        {
            try
            {
                _logger.LogInformation("Waiting for connection");
                var tcpClient = _listener.AcceptTcpClient();
                var handler = ClientConnected;
                if (handler != null)
                {
                    handler(this, new ClientEventArgs(tcpClient));
                }
            }
            catch (SocketException ex) when (ex.SocketErrorCode == SocketError.Interrupted)
            {
                throw new OperationCanceledException(ct);
            }
        }

    }
}