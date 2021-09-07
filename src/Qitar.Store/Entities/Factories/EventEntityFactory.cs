using Qitar.Events;
using Qitar.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Qitar.Store.Entities.Factories
{
    public class EventEntityFactory : IEventEntityFactory
    {
        private readonly ISerializer _serializer;

        public EventEntityFactory(ISerializer serializer )
        {
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        public async ValueTask<EventEntity> CreateEventAsync(IEvent obj)
        {
            return new EventEntity
            {
                Id = obj.StreamId,
                Version = 0, // update
                EventType = obj.GetType().AssemblyQualifiedName,
                //Payload = await _serializer.Serialize(obj).ConfigureAwait(false),

            };

        }
    }
}
