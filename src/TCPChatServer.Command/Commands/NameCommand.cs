using TCPChatServer.Command.Validators;
using TCPChatServer.Core.Command;
using TCPChatServer.Core.Command.Attributes;
using TCPChatServer.Core.Command.Models;
using TCPChatServer.Core.Command.Parsers;
using TCPChatServer.Core.Services;

namespace TCPChatServer.Command.Commands;

[CommandValidator(typeof(NameCommandValidator))]
[Command("name", "Change your name.")]
public class NameCommand : ICommand
{
    private readonly ICommandParser _commandParser;
    private readonly IUserService _userService;
    private readonly IDataService _dataService;

    public NameCommand(ICommandParser commandParser, IUserService userService, IDataService dataService)
    {
        _commandParser = commandParser;
        _userService = userService;
        _dataService = dataService;
    }

    public void Execute(CommandData commandData)
    {
        var user = _userService.Get(commandData.SenderId);
        user.Name = commandData.Parameters.First();

        _dataService.Send(commandData.SenderId, $"Your name is now {user.Name}");
    }
}