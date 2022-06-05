using System.Net.Sockets;
using TCPChatServer.Core.Models;

namespace TCPChatServer.Core.Events;

public class ClientEventArgs : EventArgs
{
    public Client Client { get; }
    public ClientEventArgs(Client client)
    {
        Client = client;
    }

}