using Harvey.Device.Connector.Bases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Harvey.Device.Connector.Implementations.PrinterDevice
{
    public class PrinterDeviceCommand: DeviceBase
    {
        public PrinterDeviceCommand(string data) : base(data)
        {

        }
        public override Task<bool> Execute()
        {
            var data = Convert<PrinterDeviceModel>();
            return Task.FromResult(true);
        }
    }
}