namespace TCPChatServer.Core.Models;

public class ReceivedData
{
    public Guid SenderId { get; }
    public string Content { get; }
    public ReceivedData(Guid senderId, string content)
    {
        SenderId = senderId;
        Content = content;
    }
}
