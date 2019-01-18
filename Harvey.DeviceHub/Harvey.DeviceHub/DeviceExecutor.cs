using Harvey.DeviceHub.Factories;
using Harvey.DeviceHub.Models;
using System.Threading.Tasks;

namespace Harvey.DeviceHub
{
    public class DeviceExecutor
    {
        public async Task<bool> ExecuteAsync(DeviceRequest request)
        {
            var serializer = SerializerFactory.CreateSerializerFromType(request.Command);
            var device = DeviceFactory.CreateDeviceFromType(request.Command);
            var data = serializer.Serialize(request.Data);
            var result = await device.ExecuteAsync(data);
            return result;
        }
    }
}