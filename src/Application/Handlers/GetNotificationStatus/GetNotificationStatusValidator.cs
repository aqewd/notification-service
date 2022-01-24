using System;
using FluentValidation;

namespace Application.Handlers.GetNotificationStatus
{
    public class GetNotificationStatusValidator : AbstractValidator<GetNotificationStatusQuery>
    {
        public GetNotificationStatusValidator()
        {
            RuleFor(v => v.Id)
                .Must(x => x != Guid.Empty);
        }
    }
}