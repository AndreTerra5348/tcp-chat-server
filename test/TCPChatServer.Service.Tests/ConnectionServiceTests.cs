using System.Net.Sockets;
using Moq;
using TCPChatServer.Core.Events;
using TCPChatServer.Core.Providers;
using Xunit;

namespace TCPChatServer.Service.Tests;

public class ConnectionServiceTests
{
    [Fact]
    public void AwaitConnection_Fires_ClientConnected_Event()
    {

    }
}