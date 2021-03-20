using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Events
{
    public interface IEventStoreProvider
    {
        ValueTask Append<TEvent>(Guid streamId, TEvent @event, int? version, CancellationToken cancellationToken = default) where TEvent : IEvent;
        ValueTask<IReadOnlyList<TEvent>> Load<TEvent>(Guid streamId, int fromVersion, DateTime? timestamp, CancellationToken cancellationToken = default) where TEvent : IEvent;
        ValueTask Delete(Guid streamId, int version, CancellationToken cancellationToken = default);
    }
}
