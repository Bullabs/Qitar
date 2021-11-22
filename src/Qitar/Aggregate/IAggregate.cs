using Qitar.Entities;
using Qitar.Events;
using Qitar.Objects;
using System;
using System.Collections.Generic;

namespace Qitar.Aggregate
{
    public interface IAggregate<TKey> : IEntity<TKey>, IVersionable
    {
        IEnumerable<IEvent> DequeueUncommittedEvents();
    }

    public interface IAggregate : IAggregate<Guid>
    {
    }
}
