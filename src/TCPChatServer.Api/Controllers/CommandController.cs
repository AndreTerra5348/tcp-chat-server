using TCPChatServer.Api.Validators;
using TCPChatServer.Core.Command.Factories;
using TCPChatServer.Core.Command.Models;
using TCPChatServer.Core.Command.Parsers;
using TCPChatServer.Core.Command.Resolvers;
using TCPChatServer.Core.Command.Services;
using TCPChatServer.Core.Models;
using TCPChatServer.Core.Services;
using FluentValidation;

namespace TCPChatServer.Api.Controllers;

public class CommandController
{
    private readonly IDataService _dataService;
    private readonly ICommandService _commandService;
    private readonly ILogger<CommandController> _logger;

    public CommandController(IDataService dataService, ICommandService commandService, ILogger<CommandController> logger)
    {
        _dataService = dataService;
        _commandService = commandService;
        _logger = logger;

        _commandService.Received += (s, e) => CommandService_Received(e.Data);
    }

    private void CommandService_Received(ReceivedData data)
    {
        var command = _commandService.ParseCommand(data.Content);
        _logger.LogInformation($"Received command: {command} from {data.SenderId}");
        if (!_commandService.Has(command))
        {
            var error = $"Command {command} not found";
            _dataService.Send(data.SenderId, error);
            _logger.LogError(error);
            return;
        }

        var commandObject = _commandService.Resolve(command);
        var commandValidator = _commandService
            .CreateValidator<AbstractValidator<CommandData>>(commandObject.GetType());
        var parameters = _commandService.ParseParameters(data.Content);
        var commandData = new CommandData(data.SenderId, parameters);
        var commandValidationResult = commandValidator!.Validate(commandData);

        if (!commandValidationResult.IsValid)
        {
            var errors = String.Join(", ", commandValidationResult.Errors.Select(x => x.ErrorMessage));
            _dataService.Send(data.SenderId, $"Command validation failed: {errors}");
            _logger.LogError($"Command validation failed: {errors}");
            return;
        }

        commandObject.Execute(commandData);
        _logger.LogInformation($"Command {command} executed successfully");
    }
}