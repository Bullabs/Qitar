using Qitar.Dependencies;
using Qitar.Messages;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Bus
{
    public class Bus : IBus
    {
        private readonly IResolver _resolver;
        private readonly Dictionary<Type, List<object>> _subscribers;

        public Bus(IResolver resolver)
        {
            _resolver = resolver ?? throw new ArgumentException(nameof(resolver));
            _subscribers = new Dictionary<Type, List<object>>();
        }

        public ValueTask Publish<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IMessage
        {
            throw new NotImplementedException();
        }

        public ValueTask Subscribe<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IMessage
        {
            throw new NotImplementedException();
        }

        public ValueTask Unsubscribe<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IMessage
        {
            throw new NotImplementedException();
        }
    }
}
