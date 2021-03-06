using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.Handlers.CreateNotification
{
    public class CreateNotificationHandler : IRequestHandler<CreateNotificationCommand, NotificationResult>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationService _notificationService;

        public CreateNotificationHandler(INotificationRepository notificationRepository, INotificationService notificationService)
        {
            _notificationRepository = notificationRepository;
            _notificationService = notificationService;
        }

        public async Task<NotificationResult> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notificationStatus = await _notificationService.Send(request.Notification, request.Type);
            var id = _notificationRepository.Create(new Notification(request.Notification, request.Type,
                notificationStatus));
            return new NotificationResult
            {
                Id = id,
                Status = notificationStatus
            };
        }
    }
}