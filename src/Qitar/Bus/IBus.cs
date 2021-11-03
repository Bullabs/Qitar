using Qitar.Messages;

namespace Qitar.Bus
{
    public interface IBus: IMessagePublisher, IMessageSubscriber
    {
    }
}