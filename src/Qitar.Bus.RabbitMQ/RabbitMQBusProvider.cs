﻿using Microsoft.Extensions.Options;
using Qitar.Events;
using Qitar.Messages;
using Qitar.Serialization;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
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
            consumer.Received += ConsumerEvent;
            var queueTag = _channel.BasicConsume(queueName, true, consumer);
            return new ValueTask<string>(queueTag);
        }

        private static async Task ConsumerEvent(object sender, BasicDeliverEventArgs message)
        {
            var type = message.BasicProperties.Type;
            var @event = message.Body
            
        }

    }
}
