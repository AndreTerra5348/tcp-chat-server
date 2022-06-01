using System.Net.Sockets;

namespace TCPChatServer.Core.Providers;

public interface ITCPListenerProvider
{
    TcpListener CreateTcpListener();
}