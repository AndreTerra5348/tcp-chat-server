using System.Net.Sockets;
using TCPChatServer.Core.Models;

namespace TCPChatServer.Core.Events;

public class ClientEventArgs : EventArgs
{
    public TcpClient TcpClient { get; }
    public ClientEventArgs(TcpClient tcpClient)
    {
        TcpClient = tcpClient;
    }

}