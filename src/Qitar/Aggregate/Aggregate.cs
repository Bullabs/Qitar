using Qitar.Events;
using Qitar.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qitar.Aggregate
{
    public class Aggregate<TKey> : IAggregate<TKey>
    {
        private readonly Queue<IEvent> _uncommittedEvents;

        public Aggregate()
        {
            _uncommittedEvents = new Queue<IEvent>();
        }

        public TKey Id { get; protected set; }

        public int Version { get; protected set; }

        object IIdentity.Id => Id;

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
