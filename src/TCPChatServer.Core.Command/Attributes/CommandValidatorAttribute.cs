namespace TCPChatServer.Core.Command.Attributes;

public class CommandValidatorAttribute : Attribute
{
    public Type ValidatorType { get; }

    public CommandValidatorAttribute(Type validatorType)
    {
        ValidatorType = validatorType;
    }
}