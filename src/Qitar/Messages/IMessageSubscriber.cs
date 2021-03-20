using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Messages
{
    public interface IMessageSubscriber
    {
        ValueTask Subscribe<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IMessage;
        ValueTask Unsubscribe<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IMessage;
    }
}
