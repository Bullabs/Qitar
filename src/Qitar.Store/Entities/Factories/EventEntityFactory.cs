using Qitar.Events;
using Qitar.Serialization;
using Qitar.Utils;
using System.Threading.Tasks;

namespace Qitar.Store.Entities.Factories
{
    public class EventEntityFactory : IEntityFactory<IEvent, EventEntity>
    {
        private readonly ISerializer _serializer;

        public EventEntityFactory(ISerializer serializer )
        {
            _serializer = serializer.NotNull();
        }

        public async ValueTask<EventEntity> CreateEntity(IEvent obj)
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
