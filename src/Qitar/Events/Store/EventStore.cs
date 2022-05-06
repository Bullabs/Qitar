using Qitar.Utils;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Events
{
    public class EventStore: IEventStore
    {
        public readonly IEventStoreProvider _eventStoreProvider;

        public EventStore(IEventStoreProvider eventStoreProvider)
        {
            _eventStoreProvider = eventStoreProvider.NotNull();
        }

        public ValueTask<TEntity> Aggregate<TEntity>(Guid streamId, int version, DateTime? timestamp, CancellationToken cancellationToken = default) where TEntity : class, new()
        {
            throw new NotImplementedException();
        }

        public async  ValueTask Append<TEvent>(Guid streamId, IEnumerable<TEvent> events, int? version, CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            foreach (var @event in events)
            {
                await Append(streamId, @event, version, cancellationToken).ConfigureAwait(false);
            }
        }

        public async ValueTask Append<TEvent>(Guid streamId, TEvent @event, int? version, CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            await _eventStoreProvider.Append(streamId, @event, null, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<IReadOnlyList<TEvent>> Load<TEvent>(Guid streamId, int fromVersion, DateTime? timestamp, CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            return await _eventStoreProvider.Load<TEvent>(streamId, fromVersion, timestamp, cancellationToken).ConfigureAwait(false);
        }
    }
}
