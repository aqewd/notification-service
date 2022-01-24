using FluentValidation;
using Infrastructure.Services.AndroidNotification;

namespace Infrastructure.Validators
{
    public class AndroidNotificationDataValidator : AbstractValidator<AndroidNotificationData>
    {
        public AndroidNotificationDataValidator()
        {
            RuleFor(notification => notification.DeviceToken)
                .NotNull()
                .Length(1, 50);

            RuleFor(notification => notification.Message)
                .NotNull()
                .Length(1, 2000);

            RuleFor(notification => notification.Title)
                .NotNull()
                .Length(1, 255);

            RuleFor(notification => notification.Condition)
                .Must(x => x is null || x.Length <= 255);
        }
    }
}