namespace RealStateApi.Interfaces
{
    public interface IMessageProducer
    {
        public void SendMessage<T>(T message);
    }
}
