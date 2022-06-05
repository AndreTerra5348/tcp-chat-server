using TCPChatServer.Core.Events;
using TCPChatServer.Core.Models;

namespace TCPChatServer.Core.Command.Services;
public interface ICommandService
{
    string ParseCommand(string command);
    IEnumerable<string> ParseParameters(string message);
    bool Has(string command);
    ICommand Resolve(string command);
    T_Validator CreateValidator<T_Validator>(Type commandType) where T_Validator : class;
}
