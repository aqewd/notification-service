using System;
using Domain.Entities;
using Domain.Enums;

namespace Application.Common.Interfaces.Repositories
{
    public interface INotificationRepository
    {
        Guid Create(Notification notification);
        NotificationStatus? GetStatusById(Guid notificationUid);
    }
}
