using Domain.Enums;

namespace Application.Common.Helpers
{
    public static class NotificationStatusHelper
    {
        public static NotificationStatus GetByCountNotification(int countNotification)
        {
            if (countNotification % 5 == 0)
            {
                return NotificationStatus.NotDelivered;
            }

            return NotificationStatus.Delivered;
        }
    }
}
