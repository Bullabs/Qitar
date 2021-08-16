using Qitar.Messages;

namespace Qitar.Events
{
    public interface IEventHandler<in TEvent>: IMessageHandler<TEvent> where TEvent : IEvent
    {
    }
}
