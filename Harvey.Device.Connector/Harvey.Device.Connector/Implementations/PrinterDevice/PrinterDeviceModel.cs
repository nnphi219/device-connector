using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harvey.Device.Connector.Implementations.PrinterDevice
{
    public class PrinterDeviceModel
    {
        public string Number { get; set; }
        public List<string> Items { get; set; }
    }
}