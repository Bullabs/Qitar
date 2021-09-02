using Qitar.Events;
using System;
using System.Collections.Generic;

namespace Qitar.Aggregate
{
    public abstract class Aggregate<TKey> : IAggregate<TKey>
    {
        private readonly Queue<IEvent> _uncommittedEvents;

        protected Aggregate()
        {
            _uncommittedEvents = new();
        }

        public TKey Id { get; protected set; }

        public int Version { get; protected set; }

        public IEnumerable<IEvent> DequeueUncommittedEvents()
        {
            var dequeuedEvents = _uncommittedEvents.ToArray();
            _uncommittedEvents.Clear();
            return dequeuedEvents;
        }

        protected void Enqueue(IEvent @event)
        {
            _uncommittedEvents.Enqueue(@event);
        }
    }
    public abstract class Aggregate : Aggregate<Guid>, IAggregate
    {

    }
}
