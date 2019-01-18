using System.Threading.Tasks;

namespace Harvey.DeviceHub
{
    public interface IDevice<TInput>
    {
        Task<bool> ExecuteAsync(TInput model);
    }
}