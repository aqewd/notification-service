using System.Threading.Tasks;
using Domain.Common;
using Domain.Enums;

namespace Application.Common.Interfaces.Services
{
    public interface INotificationSender
    {
        Task<NotificationStatus> SendNotification(INotificationData data);
    }
}
