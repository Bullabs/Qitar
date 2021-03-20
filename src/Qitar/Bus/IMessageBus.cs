using Qitar.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Bus
{
    public interface IMessageBus: IMessage
    {
        ValueTask Subscribe<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IMessage;
        ValueTask Unsubscribe<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IMessage;
        ValueTask Publish<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IMessage;
    }
}
