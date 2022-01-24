using System;
using System.Threading.Tasks;
using Application.Common.Helpers;
using Application.Common.Interfaces.Services;
using Domain.Common;
using Domain.Enums;
using Infrastructure.Validators;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Services.AndroidNotification
{
    public class AndroidNotificationSender : INotificationSender
    {
        private readonly ILogger _logger;
        private readonly AndroidNotificationDataValidator _validator;
        private static int _countNotification;

        public AndroidNotificationSender(ILogger logger)
        {
            _validator = new AndroidNotificationDataValidator();
            _logger = logger;
        }

        public async Task<NotificationStatus> SendNotification(INotificationData data)
        {
            if (data is not AndroidNotificationData notificationData)
                throw new ArgumentException();

            if (!IsValidData(notificationData))
                throw new ArgumentException();

            await TaskDelayHelper.Delay();
            _logger.LogInformation($"Send notification to android device (Sender: {nameof(AndroidNotificationSender)}) with message: {notificationData.Message}. Notification data: {JsonConvert.SerializeObject(notificationData)}");
            _countNotification++;
            return NotificationStatusHelper.GetByCountNotification(_countNotification);
        }

        private bool IsValidData(AndroidNotificationData data)
        {
            return _validator.Validate(data).IsValid;
        }
    }
}