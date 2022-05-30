using TCPChatServer.Core.Command.Models;
using FluentValidation;

namespace TCPChatServer.Command.Validators;

public class BroadcastCommandValidator : AbstractValidator<CommandData>
{
    public BroadcastCommandValidator()
    {
        RuleFor(x => x.SenderId)
            .NotNull()
            .WithMessage("SenderId is required");

        RuleFor(x => x.Parameters)
            .Must(x => x.Count() >= 1)
            .WithMessage("Parameters must be 1 or more")
            .Must(x => !string.IsNullOrWhiteSpace(x.First()))
            .WithMessage("Parameters must not be empty");
    }
}