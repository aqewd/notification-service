using System;
using Domain.Enums;

namespace Application.Common.Models
{
    public class NotificationResult
    {
        public Guid Id { get; set; }
        
        public NotificationStatus Status { get; set; }
    }
}
