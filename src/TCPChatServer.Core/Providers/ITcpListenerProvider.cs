using System.Net.Sockets;

namespace TCPChatServer.Core.Providers;

public interface ITcpListenerProvider
{
    TcpListener CreateTcpListener();
}