using System;
using System.Threading.Tasks;
using Application.Handlers.CreateNotification;
using Application.Handlers.GetNotificationStatus;
using Domain.Enums;
using Infrastructure.Services.AndroidNotification;
using Infrastructure.Services.IOsNotification;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("notification")]
    public class NotificationController : ApiController
    {
        [HttpPost("create/android")]
        public async Task<ActionResult> CreateAndroidNotification([FromBody] AndroidNotificationData data)
        {
            var command = new CreateNotificationCommand
            {
                Notification = data,
                Type = NotificationType.Android
            };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("create/ios")]
        public async Task<ActionResult> CreateIOsNotification([FromBody] IOsNotificationData data)
        {
            var command = new CreateNotificationCommand
            {
                Notification = data,
                Type = NotificationType.iOs
            };
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("status/{id:guid}")]
        public async Task<ActionResult> GetStatusById([FromRoute] Guid id)
        {
            var result = await Mediator.Send(new GetNotificationStatusQuery
            {
                Id = id
            });
            return Ok(result);
        }
    }
}