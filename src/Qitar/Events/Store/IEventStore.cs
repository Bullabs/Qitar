using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Events
{
    public interface IEventStore
    {
        ValueTask Append<TEvent>(Guid streamId, IEnumerable<TEvent> events, int? version, CancellationToken cancellationToken = default) where TEvent : IEvent;
        ValueTask Append<TEvent>(Guid streamId, TEvent @event, int? version, CancellationToken cancellationToken = default) where TEvent : IEvent;
        ValueTask<IReadOnlyList<TEvent>> Load<TEvent>(Guid streamId, int fromVersion, DateTime? timestamp, CancellationToken cancellationToken = default) where TEvent : IEvent;
    }
}
