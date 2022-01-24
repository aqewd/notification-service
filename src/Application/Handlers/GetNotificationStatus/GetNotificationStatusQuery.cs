using System;
using Application.Common.Models;
using MediatR;

namespace Application.Handlers.GetNotificationStatus
{
    public class GetNotificationStatusQuery : IRequest<NotificationResult>
    {
        public Guid Id { get; set; }
    }
}