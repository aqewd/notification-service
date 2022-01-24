using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using MediatR;

namespace Application.Handlers.GetNotificationStatus
{
    public class GetNotificationStatusHandler : IRequestHandler<GetNotificationStatusQuery, NotificationResult>
    {
        private readonly INotificationRepository _notificationRepository;

        public GetNotificationStatusHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public Task<NotificationResult> Handle(GetNotificationStatusQuery request, CancellationToken cancellationToken)
        {
            var notificationStatus = _notificationRepository.GetStatusById(request.Id);

            if (notificationStatus is null)
                throw new NotFoundException($"Notification status not found by identifier: {request.Id}");

            return Task.FromResult(new NotificationResult
            {
                Id = request.Id,
                Status = notificationStatus.Value
            });
        }
    }
}