namespace TCPChatServer.Core.Command.Resolvers;

public interface ICommandResolver
{
    ICommand Resolve(string command);
    bool Has(string command);
}