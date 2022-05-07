using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Bus
{
    public interface IBusProvider
    {
        ValueTask Publish(string queueName, Type messageType, byte[] data, TimeSpan? delay, CancellationToken cancellationToken = default);
        ValueTask<string> Subscribe(string queueName, CancellationToken cancellationToken = default);
        ValueTask<string> Unsubscribe(string queueName, CancellationToken cancellationToken = default);
    }
}
