using Application.Common.Models;
using Domain.Common;
using Domain.Enums;
using MediatR;

namespace Application.Handlers.CreateNotification
{
    public class CreateNotificationCommand : IRequest<NotificationResult>
    {
        public INotificationData Notification { get; set; }

        public NotificationType Type { get; set; }
    }
}