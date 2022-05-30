using TCPChatServer.Core.Command.Models;
using FluentValidation;

namespace TCPChatServer.Command.Validators;

public class NameCommandValidator : AbstractValidator<CommandData>
{
    public NameCommandValidator()
    {
        RuleFor(x => x.SenderId)
            .NotNull()
            .WithMessage("SenderId is required");

        RuleFor(x => x.Parameters)
            .Must(x => x.Count() == 1)
            .WithMessage("Parameters must be 1")
            .Must(x => !string.IsNullOrWhiteSpace(x.FirstOrDefault()))
            .WithMessage("Parameters must not be empty");
    }
}