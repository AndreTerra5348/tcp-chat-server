namespace TCPChatServer.Core.Command.Parsers;

public interface ICommandParser
{
    string ParseCommand(string message);
    IEnumerable<string> ParseParameters(string message);
}
