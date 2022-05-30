namespace TCPChatServer.Core.Command.Models;

public class CommandData
{
    public IEnumerable<string> Parameters { get; }
    public Guid SenderId { get; }

    public CommandData(Guid senderId, IEnumerable<string> parameters)
    {
        SenderId = senderId;
        Parameters = parameters;
    }
}