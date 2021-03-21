using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Events
{
    public interface IEventPublisher
    {
        ValueTask Publish<TEvent>(IEnumerable<TEvent> events ,CancellationToken cancellationToken = default) where TEvent : IEvent;
        ValueTask Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent;
    }
}
