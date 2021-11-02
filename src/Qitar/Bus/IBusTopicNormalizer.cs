using Qitar.Messages;
namespace Qitar.Bus
{
    internal interface IBusTopicNormalizer
    {
        string NormalizeTopic(IMessage message);
    }
}
