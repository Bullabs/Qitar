using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Messages
{
    public interface IMessagePublisher
    {
        ValueTask Publish<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : IMessage;
    }
}
