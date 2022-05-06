using Qitar.Dependencies;
using Qitar.Messages;
using Qitar.Serialization;
using Qitar.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Bus
{
    public class Bus : IBus
    {
        private readonly IResolver _resolver;
        private readonly IBusProvider _busProvider;
        private readonly ISerializer _serializer;
        private readonly Dictionary<Type, List<object>> _subscribers;

        public Bus(IResolver resolver, IBusProvider busProvider, ISerializer serializer )
        {
            _resolver = resolver.NotNull();
            _busProvider = busProvider.NotNull();
            _serializer = serializer.NotNull();
            _subscribers = new Dictionary<Type, List<object>>();
        }

        public async ValueTask Publish<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IMessage
        {
            var json = await _serializer.Serialize(message, cancellationToken).ConfigureAwait(false);

            var data = Encoding.UTF8.GetBytes(json);

            await _busProvider.Publish("", message.GetType(), data, null, cancellationToken).ConfigureAwait(false);
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
