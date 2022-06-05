using TCPChatServer.Core;
using TCPChatServer.Core.Events;
using TCPChatServer.Core.Models;
using TCPChatServer.Core.Services;

namespace TCPChatServer.Service;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Add(Client client)
    {
        _unitOfWork.ClientRepository.Add(client);
    }

    public Client Get(Guid id)
    {
        return _unitOfWork.ClientRepository.Get(id);
    }

    public IEnumerable<Client> GetAll()
    {
        return _unitOfWork.ClientRepository.GetAll();
    }

    public void Remove(Client client)
    {
        _unitOfWork.ClientRepository.Remove(client);
    }
}