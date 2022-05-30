using FluentValidation;
using TCPChatServer.Core.Models;
using TCPChatServer.Core.Command;

namespace TCPChatServer.Api.Validators;

public class ReceivedDataValidator : AbstractValidator<ReceivedData>
{
    public ReceivedDataValidator()
    {
        RuleFor(x => x.SenderId)
            .NotNull()
            .WithMessage("SenderId is required");

        RuleFor(x => x.Content)
            .Must(x => !string.IsNullOrWhiteSpace(x))
            .WithMessage("Content is required")
            .Must(x => x.StartsWith("/"))
            .WithMessage("Content must start with '/'")
            .Must(x => x.Skip(1).Count() > 0)
            .WithMessage("Content must contain at least one character after '/'");
    }
}