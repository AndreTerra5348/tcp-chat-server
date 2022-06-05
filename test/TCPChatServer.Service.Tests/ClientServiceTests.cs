using System;
using System.Net.Sockets;
using FluentAssertions;
using Moq;
using TCPChatServer.Core;
using TCPChatServer.Core.Models;
using TCPChatServer.Core.Repositories;
using TCPChatServer.Service.Tests.MockRepositories;
using Xunit;

namespace TCPChatServer.Service.Tests;

public class ClientServiceTests
{
    [Fact]
    public void Add_CallClientRepositoryAdd_OnlyOnce()
    {
        // Arrange
        var clientRepositoryMock = new MockClientRepository()
            .MockAdd();

        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock
            .Setup(x => x.ClientRepository).Returns(clientRepositoryMock.Object);

        var client = new Client(new TcpClient(), Guid.NewGuid());

        var sut = new ClientService(unitOfWorkMock.Object);

        // Act
        sut.Add(client);

        // Assert
        clientRepositoryMock.Verify(x => x.Add(It.IsAny<Client>()), Times.Once);
    }

    [Fact]
    public void Get_CallClientRepositoryGet_ReturnClient()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var clientRepositoryMock = new MockClientRepository()
            .MockGet(guid);

        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock
            .Setup(x => x.ClientRepository).Returns(clientRepositoryMock.Object);


        var sut = new ClientService(unitOfWorkMock.Object);

        // Act
        var result = sut.Get(guid);

        // Assert
        var client = result.Should().BeOfType<Client>().Subject;
        client.Id.Should().Be(guid);
    }

    [Fact]
    public void GetAll_CallClientRepositoryGetAll_ReturnClient()
    {
        // Arrange
        var clientRepositoryMock = new MockClientRepository()
            .MockGetAll(new Client(new TcpClient(), Guid.NewGuid()));

        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock
            .Setup(x => x.ClientRepository).Returns(clientRepositoryMock.Object);

        var sut = new ClientService(unitOfWorkMock.Object);

        // Act
        var result = sut.GetAll();

        // Assert
        result.Should().BeOfType<Client[]>();
        result.Should().HaveCount(1);
    }

    [Fact]
    public void Remove_CallClientRepositoryRemove_OnlyOnce()
    {
        // Arrange
        var clientRepositoryMock = new MockClientRepository()
            .MockRemove();

        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock
            .Setup(x => x.ClientRepository).Returns(clientRepositoryMock.Object);
        var client = new Client(new TcpClient(), Guid.NewGuid());

        var sut = new ClientService(unitOfWorkMock.Object);

        // Act
        sut.Remove(client);

        // Assert
        clientRepositoryMock.Verify(x => x.Remove(It.IsAny<Client>()), Times.Once);
    }
}