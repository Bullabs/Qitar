using Qitar.Entities;
using Qitar.Objects;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity, IIdentity
    {
        ValueTask<TEntity> Insert(TEntity entity, CancellationToken cancellationToken = default);
        ValueTask<bool> Update(TEntity entity, CancellationToken cancellationToken = default);
        ValueTask<bool> Delete(TEntity entity, CancellationToken cancellationToken = default);
        ValueTask<TEntity> GetById(object id, CancellationToken cancellationToken = default);
    }
}
