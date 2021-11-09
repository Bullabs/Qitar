using Qitar.Objects.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Messages
{
    public interface IMessageHandler<in TMessage, TResponse> where TMessage : IMessage where TResponse : IResult
    {
        ValueTask<TResponse> Handle(TMessage Message, CancellationToken cancellationToken = default);
    }
    public interface IMessageHandler<in TMessage> where TMessage : IMessage
    {
        ValueTask Handle(TMessage Message, CancellationToken cancellationToken = default);
    }
}