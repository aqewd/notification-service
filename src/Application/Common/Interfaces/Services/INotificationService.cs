using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;

namespace Application.Common.Interfaces.Services
{
    public interface INotificationService
    {
        Task<NotificationStatus> Send(INotificationData data, NotificationType type);
    }
}
