using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Messages
{
    public interface IMessageSubscriber
    {
        ValueTask Subscribe<TMessage>(IMessageHandler<TMessage> handler, CancellationToken cancellationToken = default) where TMessage : IMessage;
        ValueTask Unsubscribe<TMessage>(IMessageHandler<TMessage> message, CancellationToken cancellationToken = default) where TMessage : IMessage;
    }
}
