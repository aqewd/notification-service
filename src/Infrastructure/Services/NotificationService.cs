using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Services;
using Domain.Common;
using Domain.Enums;
using Infrastructure.Services.AndroidNotification;
using Infrastructure.Services.IOsNotification;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        private readonly AndroidNotificationSender _androidNotificationSender;
        private readonly IOsNotificationSender _iosNotificationSender;

        public NotificationService(ILogger<NotificationService> logger)
        {
            _androidNotificationSender = new AndroidNotificationSender(logger);
            _iosNotificationSender = new IOsNotificationSender(logger);
        }

        public Task<NotificationStatus> Send(INotificationData data, NotificationType type)
        {
            var sender = GetSender(type);
            return sender.SendNotification(data);
        }

        private INotificationSender GetSender(NotificationType type) => type switch
        {
            NotificationType.iOs => _iosNotificationSender,
            NotificationType.Android => _androidNotificationSender,
            _ => throw new NotFoundException()
        };
    }
}
