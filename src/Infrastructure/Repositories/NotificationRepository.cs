using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private static readonly IList<Notification> _notifications = new List<Notification>();

        public Guid Create(Notification notification)
        {
            notification.SetId(Guid.NewGuid());
            _notifications.Add(notification);
            return notification.Id;
        }

        public NotificationStatus? GetStatusById(Guid notificationUid)
        {
            return _notifications.FirstOrDefault(x => x.Id == notificationUid)?.Status;
        }
    }
}
