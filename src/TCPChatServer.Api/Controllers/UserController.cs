using TCPChatServer.Core.Models;
using TCPChatServer.Core.Services;

namespace TCPChatServer.Api.Controllers;

public class UserController
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService,
        ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    public User Create(Guid clientId)
    {
        _logger.LogInformation("User created");
        var user = new User(clientId);
        _userService.Add(user);
        return user;
    }
}