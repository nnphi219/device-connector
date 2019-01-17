using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Harvey.Device.Connector.Bases
{
    public abstract class DeviceBase
    {
        private readonly string _data;
        public DeviceBase(string data)
        {
            _data = data;
        }

        protected T Convert<T>()
        {
            return JsonConvert.DeserializeObject<T>(_data);
        }

        public abstract Task<bool> Execute();
    }
}