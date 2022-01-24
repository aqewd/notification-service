using System;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Notification : AuditableEntity
    {
        public Notification(INotificationData data, NotificationType type, NotificationStatus status)
        {
            Data = data;
            Status = status;
            Type = type;
            Created = DateTime.UtcNow;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

        public INotificationData Data { get; private set; }

        public NotificationStatus Status { get; private set; }

        public NotificationType Type { get; private set; }
    }
}
