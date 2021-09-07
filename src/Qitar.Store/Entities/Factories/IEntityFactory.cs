using Qitar.Entities;
using System.Threading.Tasks;

namespace Qitar.Store.Entities.Factories
{
    public interface IEntityFactory<TSource, TDestination> where TDestination : Entity
    {
        ValueTask<TDestination> CreateEntity(TSource obj);
    }
}
