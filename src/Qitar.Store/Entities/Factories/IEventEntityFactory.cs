using Qitar.Events;
using System.Threading.Tasks;

namespace Qitar.Store.Entities.Factories
{
    public interface IEventEntityFactory
    {
        ValueTask<EventEntity> CreateEventAsync(IEvent obj);
    }
}
