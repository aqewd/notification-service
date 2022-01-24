using System;

namespace Application.Common.Interfaces.Repositories.Models
{
    public class DeviceModel
    {
        public Guid Uid { get; set; }
        public string HardwareId { get; set; }
        public Guid CustomerUid { get; set; }
    }
}
