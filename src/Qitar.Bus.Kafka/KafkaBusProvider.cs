using Confluent.Kafka;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Bus.Kafka
{
    public class KafkaBusProvider : IBusProvider
    {
        private readonly IProducer<Guid, byte[]> _producer;

        public KafkaBusProvider(IProducer<Guid, byte[]> producer )
        {
            _producer = producer ?? throw new ArgumentNullException(nameof(producer));
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
    }
}
