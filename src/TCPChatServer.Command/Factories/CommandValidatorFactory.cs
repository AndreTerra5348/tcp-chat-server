using System.Reflection;
using TCPChatServer.Core.Command.Attributes;
using TCPChatServer.Core.Command.Factories;

namespace TCPChatServer.Command.Factories;

public class CommandValidatorFactory : ICommandValidatorFactory
{
    public T_Validator CreateValidator<T_Validator>(Type commandType) where T_Validator : class
    {
        var commandValidatorAttribute = commandType.GetCustomAttribute<CommandValidatorAttribute>();
        var commandValidatorType = commandValidatorAttribute!.ValidatorType;
        return (Activator.CreateInstance(commandValidatorType) as T_Validator)!;
    }
}