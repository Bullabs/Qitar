using Microsoft.Extensions.Options;
using Qitar.Events;
using Qitar.Serialization;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Bus.RabbitMQ
{
    public class RabbitMQBusProvider : IBusProvider
    {
        private readonly IModel _channel;
        private readonly IEventPublisher _eventPublisher;
        private readonly ISerializer _serializer;
        private readonly RabbitMQOptions _options;

        public RabbitMQBusProvider(IModel channel, IEventPublisher eventPublisher, ISerializer serializer, IOptions<RabbitMQOptions> options)
        {
            _channel = channel ?? throw new ArgumentNullException(nameof(channel));
            _eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
            _options = options.Value;
        }

        public ValueTask Publish(string topic, Type messageType, byte[] data, TimeSpan? delay, CancellationToken cancellationToken = default)
        {
            var basicProps = _channel.CreateBasicProperties();
            basicProps.MessageId = Guid.NewGuid().ToString("N");
            basicProps.Type = messageType.ToString();

            if(delay.HasValue && delay.Value> TimeSpan.Zero)
            {
                basicProps.Headers = new Dictionary<string,object> { { "x-delay", Convert.ToInt32(delay.Value.TotalMilliseconds) } };
            }

            _channel.BasicPublish(topic, String.Empty, basicProps, data);

            return default;

        }

        public ValueTask<string> Subscribe(string queueName, CancellationToken cancellationToken = default)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.Received += ConsumerMessage;
            var queueTag = _channel.BasicConsume(queueName, true, consumer);
            return new ValueTask<string>(queueTag);
        }

        private async Task ConsumerMessage(object sender, BasicDeliverEventArgs message)
        {
            var @event = await _serializer.Deserialize<IEvent>(message.Body.ToArray(), default).ConfigureAwait(false);

            await _eventPublisher.Publish(@event, default).ConfigureAwait(false);
        }
    }
}