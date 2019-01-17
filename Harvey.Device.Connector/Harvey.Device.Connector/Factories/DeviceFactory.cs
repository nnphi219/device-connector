using Harvey.Device.Connector.Bases;
using Harvey.Device.Connector.Enums;
using Harvey.Device.Connector.Implementations.PrinterDevice;

namespace Harvey.Device.Connector.Factories
{
    public class DeviceFactory
    {
        public static DeviceBase CreateDeviceFromType(Enums.Device device, string data)
        {
            switch (device)
            {
                case Enums.Device.Printer:
                    return new PrinterDeviceCommand(data);
                default:
                    throw new System.NotSupportedException("abc xyz");
            }
        }
    }
}