using Microsoft.Extensions.Options;
using Qitar.Messages;
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
        private readonly RabbitMQOptions _options;

        public RabbitMQBusProvider(IModel channel, IOptions<RabbitMQOptions> options)
        {
            _channel = channel ?? throw new ArgumentNullException(nameof(channel));
            _options = options.Value;
        }

        public ValueTask Publish(string messageType, byte[] data, TimeSpan? delay, CancellationToken cancellationToken = default)
        {
            var basicProps = _channel.CreateBasicProperties();
            basicProps.MessageId = Guid.NewGuid().ToString("N");
            basicProps.Type = messageType;

            if(delay.HasValue && delay.Value> TimeSpan.Zero)
            {
                basicProps.Headers = new Dictionary<string,object> { { "x-delay", Convert.ToInt32(delay.Value.TotalMilliseconds) } };
            }

            _channel.BasicPublish(_options.Topic, String.Empty, basicProps, data);

            return default;

        }

        public ValueTask<string> Subscribe(string queueName, CancellationToken cancellationToken = default)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            var queueTag = _channel.BasicConsume(queueName, true, consumer);
            return new ValueTask<string>(queueTag);
        }
    }
}
