using System;
using System.Threading.Tasks;
using Application.Common.Helpers;
using Application.Common.Interfaces.Services;
using Application.Common.Models;
using Domain.Common;
using Domain.Enums;
using Infrastructure.Validators;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Services.IOsNotification
{
    public class IOsNotificationSender : INotificationSender
    {
        private readonly ILogger _logger;
        private readonly IOsNotificationDataValidator _validator;
        private static int _countNotification;

        public IOsNotificationSender(ILogger logger)
        {
            _validator = new IOsNotificationDataValidator();
            _logger = logger;
        }

        public async Task<NotificationStatus> SendNotification(INotificationData data)
        {
            if (data is not IOsNotificationData notificationData)
                throw new ArgumentException();

            if (!IsValidData(notificationData))
                throw new ArgumentException();

            await TaskDelayHelper.Delay();
            _logger.LogInformation($"Send notification to iOs device (Sender: {nameof(IOsNotificationSender)}) with alert: {notificationData.Alert}. Notification data: {JsonConvert.SerializeObject(notificationData)}");

            _countNotification++;
            return NotificationStatusHelper.GetByCountNotification(_countNotification);
        }

        private bool IsValidData(IOsNotificationData data)
        {
            return _validator.Validate(data).IsValid;
        }
    }
}
