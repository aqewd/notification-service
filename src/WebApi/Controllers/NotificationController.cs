using System;
using System.Threading.Tasks;
using Application.Handlers.CreateNotification;
using Application.Handlers.GetNotificationStatus;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("notification")]
    public class NotificationController : ApiController
    {
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateNotificationModel model)
        {
            if (model is null)
                return BadRequest();

            var command = new CreateNotificationCommand
            {
                Notification = model.GetDataByType(),
                Type = model.Type
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