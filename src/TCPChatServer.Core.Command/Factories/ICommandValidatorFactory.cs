namespace TCPChatServer.Core.Command.Factories;

public interface ICommandValidatorFactory
{
    T_Validator CreateValidator<T_Validator>(Type commandType) where T_Validator : class;
}