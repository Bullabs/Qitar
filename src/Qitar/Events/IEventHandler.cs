using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        ValueTask Handle(TEvent @event, CancellationToken cancellationToken = default);
    }
}
