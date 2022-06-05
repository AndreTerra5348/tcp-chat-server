using System;
using System.Net.Sockets;
using Moq;
using TCPChatServer.Core.Models;
using TCPChatServer.Core.Repositories;

namespace TCPChatServer.Service.Tests.MockRepositories;

public class MockClientRepository : Mock<IClientRepository>
{
    public MockClientRepository MockAdd()
    {
        Setup(x => x.Add(It.IsAny<Client>()));
        return this;
    }

    public MockClientRepository MockGet(Guid id)
    {
        Setup(x => x.Get(id))
            .Returns(new Client(new TcpClient(), id));
        return this;
    }

    public MockClientRepository MockGetAll(params Client[] clients)
    {
        Setup(x => x.GetAll())
            .Returns(clients);
        return this;
    }

    public MockClientRepository MockRemove()
    {
        Setup(x => x.Remove(It.IsAny<Client>()));
        return this;
    }
}