using Qitar.Entities;
using Qitar.Objects;
using Qitar.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.EntityFramework
{
    public class EntityFrameworkRepository<TEntity> : IRepository<TEntity>, IReadonlyRepository<TEntity> where TEntity : class, IEntity ,IIdentity
    {
        private readonly IDbContextFactory _dbContextFactory;

        public EntityFrameworkRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public ValueTask<bool> Delete(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> GetById(object id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<TEntity> Insert(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
