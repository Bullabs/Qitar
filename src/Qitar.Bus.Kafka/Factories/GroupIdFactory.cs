using Qitar.Messages;
using Qitar.Utils.System;
using System;

namespace Qitar.Bus.Kafka.Factories
{
    public class GroupIdFactory : IGroupIdFactory
    {
        private readonly ISystemInfo _systemInfo;

        public GroupIdFactory(ISystemInfo systemInfo)
        {
            _systemInfo = systemInfo ?? throw new ArgumentNullException(nameof(systemInfo));
        }

        public string Create<TMessage>() where TMessage : IMessage
        {
            var type = typeof(TMessage);

            return $"{type.FullName}.{_systemInfo.ApplicationName}";
        }
    }
}
