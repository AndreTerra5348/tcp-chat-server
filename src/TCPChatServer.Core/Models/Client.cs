using System;
using System.Net.Sockets;
using System.Text;

namespace TCPChatServer.Core.Models;

public class Client
{
    public TcpClient TcpClient { get; }
    public Guid Id { get; }

    public Client(TcpClient tcpClient, Guid id)
    {
        TcpClient = tcpClient;
        Id = id;
    }
}