using Qitar.Factories;

namespace Qitar.Messages
{
    public interface IMessageFactory<TObject> : IFactory<TObject, IMessage> where TObject : class
    {
    }
}
