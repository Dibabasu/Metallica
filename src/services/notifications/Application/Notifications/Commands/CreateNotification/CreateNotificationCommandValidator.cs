using FluentValidation;

namespace Application.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandValidator: AbstractValidator<CreateNotificationCommand>
    {
        public CreateNotificationCommandValidator()
        {
             RuleFor(v => v.TradeId)
            .NotEmpty();
        }
    }
}