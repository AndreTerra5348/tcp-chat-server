using System.Net;
using System.Net.Sockets;
using TCPChatServer.Core.Providers;

namespace TCPChatServer.Api.Providers;

public class TcpListenerProvider : ITCPListenerProvider
{
    private readonly IConfiguration _configuration;

    public TcpListenerProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TcpListener CreateTcpListener()
    {
        var port = _configuration.GetValue<int>("Port");
        return new TcpListener(IPAddress.Any, port);
    }
}