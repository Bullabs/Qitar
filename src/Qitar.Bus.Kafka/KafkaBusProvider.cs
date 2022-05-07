using Confluent.Kafka;
using Qitar.Utils;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Bus.Kafka
{
    public class KafkaBusProvider : IBusProvider
    {
        private readonly IProducer<Guid, byte[]> _producer;
        private readonly IConsumer<Guid, byte[]> _consumer;

        public KafkaBusProvider(IProducer<Guid, byte[]> producer , IConsumer<Guid, byte[]> consumer)
        {
            _producer = producer.NotNull();
            _consumer = consumer.NotNull();
        }

        public async  ValueTask Publish(string topic, Type messageType, byte[] data, TimeSpan? delay, CancellationToken cancellationToken = default)
        {
            var headers = new Headers
            {
                {"x-delay", Encoding.UTF8.GetBytes(delay.ToString()) },
                {"x-message-type", Encoding.UTF8.GetBytes(messageType.Name) }
            };

            var message = new Message<Guid, byte[]>()
            {
                Key = Guid.NewGuid(),
                Value = data,
                Headers = headers
            };

            await _producer.ProduceAsync(topic, message, cancellationToken).ConfigureAwait(false);
        }

        public ValueTask<string> Subscribe(string queueName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> Unsubscribe(string queueName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
