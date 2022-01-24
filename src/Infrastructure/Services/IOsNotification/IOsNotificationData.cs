using Domain.Common;

namespace Infrastructure.Services.IOsNotification
{
    public class IOsNotificationData : INotificationData
    {
        public string PushToken { get; set; }

        public string Alert { get; set; }

        public int Priority { get; set; } = 10;

        public bool IsBackground { get; set; } = true;
    }
}
