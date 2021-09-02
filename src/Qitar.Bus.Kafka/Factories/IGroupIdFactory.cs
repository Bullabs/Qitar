using Qitar.Messages;

namespace Qitar.Bus.Kafka.Factories
{
    public interface IGroupIdFactory
    {
        string Create<TMessage>() where TMessage : IMessage;
    }
}
