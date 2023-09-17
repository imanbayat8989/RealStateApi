namespace RealStateApi.Interfaces
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
