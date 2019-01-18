using System.Threading.Tasks;

namespace Harvey.DeviceHub.Implementations.Espson
{
    public class EpsonPrinterDevice : IDevice<byte[]>
    {

        public Task<bool> ExecuteAsync(byte[] model)
        {
            var result = false;
            try
            {
                result = RawPrinterHelper.SendValueToPrinter("EPSON TM-T81 Receipt", model);
            }
            catch (System.Exception)
            {
                result = false;
            }
            return Task.FromResult(result);
        }
    }
}