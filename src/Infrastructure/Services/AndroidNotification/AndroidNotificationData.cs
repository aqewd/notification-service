using Domain.Common;

namespace Infrastructure.Services.AndroidNotification
{
    public class AndroidNotificationData : INotificationData
    {
        public string DeviceToken { get; set; }

        public string Message { get; set; }

        public string Title { get; set; }

        public string Condition { get; set; }
    }
}
