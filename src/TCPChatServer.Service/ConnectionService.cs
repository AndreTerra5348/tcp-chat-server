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

    public ConnectionService(ITCPListenerProvider tcpListenerProvider, ILogger<ConnectionService> logger)
    {
        _listener = tcpListenerProvider.CreateTcpListener();
        _listener.Start();
        _logger = logger;
        _logger.LogInformation("Server started");
    }

    public async Task<TcpClient> ListenAsync(CancellationToken ct)
    {
        using (ct.Register(() => _listener.Stop()))
        {
            try
            {
                _logger.LogInformation("Waiting for connection");
                return await _listener.AcceptTcpClientAsync(ct);
            }
            catch (SocketException ex) when (ex.SocketErrorCode == SocketError.Interrupted)
            {
                throw new OperationCanceledException(ct);
            }
        }
    }
}