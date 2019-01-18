namespace Harvey.DeviceHub
{
    public interface ISerializer<TOutput>
    {
        TOutput Serialize(string data);
    }
}