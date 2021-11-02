using Qitar.Messages;
using Qitar.Tenancy;
using Qitar.Utils;

namespace Qitar.Bus
{
    internal class BusTopicNormalizer : IBusTopicNormalizer
    {

        private readonly ICurrentTenant _tenant;
        private readonly IBusOptions _options;
        public BusTopicNormalizer(ICurrentTenant tenant)
        {
            _tenant = tenant.NotNull();
        }

        public string NormalizeTopic(IMessage message)
        {
            var key = message.GetType().Name.ToLower();
            var normalizedTopic = $"Q:{_options.TopicPrefix}{key}";

            if (_tenant.Id.HasValue)
            {
                normalizedTopic = $"T:{_tenant.Id.Value},{normalizedTopic}";
            }

            return normalizedTopic;
        }
    }
}
