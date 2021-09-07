using Qitar.Bus;
using Qitar.Dependencies;
using Qitar.Metrics;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Events
{
    public class EventPublisher : IEventPublisher
    {
        private readonly IResolver _resolver;
        private readonly IBus _bus;
        private readonly IMetrics _metrics;

        public EventPublisher(IResolver resolver, IBus bus, IMetrics metrics)
        {
            _resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
            _metrics = metrics ?? throw new ArgumentNullException(nameof(metrics));
        }

        public async ValueTask Publish<TEvent>(IEnumerable<TEvent> events, CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            foreach(var @event in events)
            {
                await Publish(@event, cancellationToken).ConfigureAwait(false);
            }
        }

        public async ValueTask Publish<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent
        {
            await _metrics.Counter(@event, cancellationToken).ConfigureAwait(false);

            var handlers = _resolver.ResolveAll<IEventHandler<TEvent>>();

            foreach (var handler in handlers)
            {
                await handler.Handle(@event).ConfigureAwait(false);
            }

            if (@event is IBusMessage message)
            {
                await _bus.Publish(@event, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}

