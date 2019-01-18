using Harvey.DeviceHub.Enums;

namespace Harvey.DeviceHub.Models
{
    public class DeviceRequest
    {
        public DeviceCommand Command { get; set; }
        public string Data { get; set; }
    }
}