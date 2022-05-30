using TCPChatServer.Core.Command.Models;

namespace TCPChatServer.Core.Command;

public interface ICommand
{
    void Execute(CommandData commandData);
}