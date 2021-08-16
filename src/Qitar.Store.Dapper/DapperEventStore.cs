using Qitar.Events;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Dapper
{
    public class DapperEventStore : IEventStoreProvider
    {
        public ValueTask Append<TEvent>(Guid streamId, TEvent @event, int? version, CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }

        public ValueTask Delete(Guid streamId, int version, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IReadOnlyList<TEvent>> Load<TEvent>(Guid streamId, int fromVersion, DateTime? timestamp, CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            throw new NotImplementedException();
        }
    }
}
