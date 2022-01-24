using System;
using Domain.Common;
using Domain.Enums;
using Infrastructure.Services.AndroidNotification;
using Infrastructure.Services.IOsNotification;

namespace WebApi.Models
{
    public class CreateNotificationModel
    {
        public AndroidNotificationData AndroidData { get; set; }
        public IOsNotificationData IOsData { get; set; }
        public NotificationType Type { get; set; }

        public INotificationData GetDataByType()
        {
            return Type switch
            {
                NotificationType.iOs => IOsData,
                NotificationType.Android => AndroidData,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
