using Harvey.DeviceHub.Enums;
using Harvey.DeviceHub.Implementations.Espson;

namespace Harvey.DeviceHub.Factories
{
    public class SerializerFactory
    {
        public static dynamic CreateSerializerFromType(DeviceCommand device)
        {
            switch (device)
            {
                case DeviceCommand.PrintReceipt:
                    return new EsponPrintReceiptSerializer();
                default:
                    throw new System.NotSupportedException($"Device hub didnot support serilizer for command {device.ToString()}");
            }
        }
    }
}