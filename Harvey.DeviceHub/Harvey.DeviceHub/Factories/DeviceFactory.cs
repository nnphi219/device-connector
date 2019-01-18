using Harvey.DeviceHub.Enums;
using Harvey.DeviceHub.Implementations.Espson;

namespace Harvey.DeviceHub.Factories
{
    public class DeviceFactory
    {
        public static dynamic CreateDeviceFromType(DeviceCommand device)
        {
            switch (device)
            {
                case DeviceCommand.PrintReceipt:
                    return new EpsonPrinterDevice();
                default:
                    throw new System.NotSupportedException($"Device hub didnot support device for command {device.ToString()}");
            }
        }
    }
}