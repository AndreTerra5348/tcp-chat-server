using TCPChatServer.Core;
using TCPChatServer.Core.Models;
using TCPChatServer.Core.Services;

namespace TCPChatServer.Service;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void Add(User user)
    {
        _unitOfWork.UserRepository.Add(user);
    }

    public User Get(Guid id)
    {
        return _unitOfWork.UserRepository.Get(id);
    }

    public User Get(string name)
    {
        return _unitOfWork.UserRepository.Get(name);
    }

    public void Remove(User user)
    {
        _unitOfWork.UserRepository.Remove(user);
    }
}
