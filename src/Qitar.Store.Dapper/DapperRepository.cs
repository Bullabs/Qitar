using Dapper.Contrib.Extensions;
using Qitar.Entities;
using Qitar.Repositories;
using Qitar.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Dapper
{
    public class DapperRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly IDbConnection _dbConnection;

        public DapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection.NotNull();
        }

        public async ValueTask Delete(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.NotNull();

            await _dbConnection.DeleteAsync(entity).ConfigureAwait(false);
        }

        public ValueTask Delete(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async ValueTask DeleteMany(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                await Delete(entity, cancellationToken).ConfigureAwait(false);
            }
        }

        public ValueTask<TEntity> Find(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<TEntity> GetById(object id, CancellationToken cancellationToken = default)
        {
            id.NotNull();

            return await _dbConnection.GetAsync<TEntity>(id).ConfigureAwait(false);
        }

        public async ValueTask Insert(TEntity entity, CancellationToken cancellationToken = default)
        {

            entity.NotNull();

            await _dbConnection.InsertAsync(entity).ConfigureAwait(false);
        }

        public async ValueTask InsertMany(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
           foreach(var entity in entities)
            {
                await Insert(entity, cancellationToken).ConfigureAwait(false);
            }
        }

        public async ValueTask Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.NotNull();

            await _dbConnection.UpdateAsync(entity).ConfigureAwait(false);
        }

        public async ValueTask UpdateMany(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            foreach (var entity in entities)
            {
                await Update(entity, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}
