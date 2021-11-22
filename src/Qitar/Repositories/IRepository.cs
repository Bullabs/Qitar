using Qitar.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Repositories
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity> : IReadonlyRepository<TEntity>, IQueryRepository<TEntity> where TEntity : class, IEntity
    {
        ValueTask Insert(TEntity entity, CancellationToken cancellationToken = default);
        ValueTask InsertMany(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        ValueTask Update(TEntity entity, CancellationToken cancellationToken = default);
        ValueTask UpdateMany(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        ValueTask Delete(TEntity entity, CancellationToken cancellationToken = default);
        ValueTask DeleteMany(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
