using System.Net.Sockets;
using TCPChatServer.Core.Models;

namespace TCPChatServer.Core.Events;

public class TcpClientEventArgs : EventArgs
{
    public TcpClient TcpClient { get; }
    public TcpClientEventArgs(TcpClient tcpClient)
    {
        TcpClient = tcpClient;
    }

}