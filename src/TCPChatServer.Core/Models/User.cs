namespace TCPChatServer.Core.Models;

public class User
{
    public Guid ClientId { get; }
    public string Name { get; set; } = "Unknown";
    public ConsoleColor Color { get; set; } = ConsoleColor.White;

    public User(Guid clientId)
    {
        ClientId = clientId;
    }
}