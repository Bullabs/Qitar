using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Bus.Kafka
{
    public class KafkaBusProvider : IBusProvider
    {
        public KafkaBusProvider()
        {

        }

        public ValueTask Publish(string messageType, byte[] data, TimeSpan? delay, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<string> Subscribe(string queueName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
