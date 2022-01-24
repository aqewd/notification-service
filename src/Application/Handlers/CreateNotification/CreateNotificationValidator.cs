using FluentValidation;

namespace Application.Handlers.CreateNotification
{
    public class CreateNotificationValidator : AbstractValidator<CreateNotificationCommand>
    {
        public CreateNotificationValidator()
        {
            RuleFor(v => v.Notification)
                .Must(x => x is not null);
        }
    }
}