using System.Net.Sockets;
using TCPChatServer.Core.Models;

namespace TCPChatServer.Core.Events;

public class TCPClientEventArgs : EventArgs
{
    public TcpClient TcpClient { get; }
    public TCPClientEventArgs(TcpClient tcpClient)
    {
        TcpClient = tcpClient;
    }

}