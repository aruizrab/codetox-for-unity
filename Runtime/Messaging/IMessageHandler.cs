namespace Codetox.Messaging
{
    public interface IMessageHandler<in T>
    {
        void HandleMessage(T message);
    }
}