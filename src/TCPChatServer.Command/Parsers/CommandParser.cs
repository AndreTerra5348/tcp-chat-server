using TCPChatServer.Core.Command.Parsers;

namespace TCPChatServer.Command.Parsers;

public class CommandParser : ICommandParser
{
    public string ParseCommand(string message)
    {
        return message
            .Split(' ')
            .FirstOrDefault()?
            .TrimStart('/')
            ?? String.Empty;
    }

    public IEnumerable<string> ParseParameters(string message)
    {
        var parameters = message.Split(' ');
        if (parameters.Length <= 1)
        {
            return new string[0];
        }
        return parameters.Skip(1);
    }
}
