using System.Reflection;
using TCPChatServer.Core.Command.Resolvers;
using TCPChatServer.Core.Command.Attributes;
using TCPChatServer.Core.Command;

namespace TCPChatServer.Command.Resolvers;

public class CommandResolver : ICommandResolver
{
    private readonly Dictionary<string, ICommand> _commandMap;

    public CommandResolver(IEnumerable<ICommand> commands)
    {
        _commandMap = commands
            .Where(c => c.GetType().GetCustomAttribute<CommandAttribute>() != null)
            .ToDictionary(c => c.GetType().GetCustomAttribute<CommandAttribute>()!.Name);
    }

    public ICommand Resolve(string command)
    {
        return _commandMap[command];
    }

    public bool Has(string command)
    {
        return _commandMap.ContainsKey(command);
    }
}