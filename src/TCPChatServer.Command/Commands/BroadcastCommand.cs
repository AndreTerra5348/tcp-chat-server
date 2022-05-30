using TCPChatServer.Command.Validators;
using TCPChatServer.Core.Command;
using TCPChatServer.Core.Command.Attributes;
using TCPChatServer.Core.Command.Models;
using TCPChatServer.Core.Services;

namespace TCPChatServer.Command.Commands;

[CommandValidator(typeof(BroadcastCommandValidator))]
[Command("broadcast", "Broadcast a message to all connected clients.")]
public class BroadcastCommand : ICommand
{
    private readonly IDataService _dataService;
    private readonly IUserService _userService;

    public BroadcastCommand(IDataService dataService, IUserService userService)
    {
        _dataService = dataService;
        _userService = userService;
    }

    public void Execute(CommandData commandData)
    {
        var content = String.Join(" ", commandData.Parameters);
        var user = _userService.Get(commandData.SenderId);
        var message = $"/{user.Color}/{user.Name}> {content}";
        _dataService.Broadcast(commandData.SenderId, message);
    }
}