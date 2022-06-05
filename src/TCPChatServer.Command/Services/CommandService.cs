using TCPChatServer.Core.Command;
using TCPChatServer.Core.Command.Factories;
using TCPChatServer.Core.Command.Parsers;
using TCPChatServer.Core.Command.Resolvers;
using TCPChatServer.Core.Command.Services;
using TCPChatServer.Core.Events;
using TCPChatServer.Core.Models;

namespace TCPChatServer.Command.Services;

public class CommandService : ICommandService
{
    private readonly ICommandParser _commandParser;
    private readonly ICommandResolver _commandResolver;
    private readonly ICommandValidatorFactory _commandValidatorFactory;


    public CommandService(ICommandParser commandParser,
        ICommandResolver commandResolver,
        ICommandValidatorFactory commandValidatorFactory)
    {
        _commandParser = commandParser;
        _commandResolver = commandResolver;
        _commandValidatorFactory = commandValidatorFactory;
    }
    public T_Validator CreateValidator<T_Validator>(Type commandType) where T_Validator : class
    {
        return _commandValidatorFactory.CreateValidator<T_Validator>(commandType);
    }

    public bool Has(string command)
    {
        return _commandResolver.Has(command);
    }

    public string ParseCommand(string command)
    {
        return _commandParser.ParseCommand(command);
    }

    public IEnumerable<string> ParseParameters(string message)
    {
        return _commandParser.ParseParameters(message);
    }

    public ICommand Resolve(string command)
    {
        return _commandResolver.Resolve(command);
    }
}