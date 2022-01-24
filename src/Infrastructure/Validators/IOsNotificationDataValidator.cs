using FluentValidation;
using Infrastructure.Services.IOsNotification;

namespace Infrastructure.Validators
{
    public class IOsNotificationDataValidator : AbstractValidator<IOsNotificationData>
    {
        public IOsNotificationDataValidator()
        {
            RuleFor(notification => notification.PushToken)
                .NotNull()
                .Length(1, 50);

            RuleFor(notification => notification.Alert)
                .NotNull()
                .Length(1, 2000);
        }
    }
}