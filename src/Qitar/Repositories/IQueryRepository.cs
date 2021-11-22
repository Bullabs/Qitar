using Qitar.Entities;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Repositories
{
    public interface IQueryRepository<TEntity> : IRepository where TEntity : class, IEntity
    {
        ValueTask<TEntity> Find(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        ValueTask Delete(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
