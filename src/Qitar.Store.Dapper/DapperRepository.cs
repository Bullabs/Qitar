﻿using Dapper.Contrib.Extensions;
using Qitar.Entities;
using Qitar.Objects;
using Qitar.Repositories;
using Qitar.Utils;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Dapper
{
    public class DapperRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, IIdentity
    {
        private readonly IDbConnection _dbConnection;

        public DapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentException(nameof(dbConnection));
        }

        public async ValueTask<bool> Delete(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.NotNull();

            return await _dbConnection.DeleteAsync(entity).ConfigureAwait(false);
        }

        public async ValueTask<TEntity> GetById(object id, CancellationToken cancellationToken = default)
        {
            id.NotNull();

            return await _dbConnection.GetAsync<TEntity>(id).ConfigureAwait(false);
        }

        public async ValueTask<TEntity> Insert(TEntity entity, CancellationToken cancellationToken = default)
        {

            entity.NotNull();

            await _dbConnection.InsertAsync(entity).ConfigureAwait(false);

            return entity;
        }

        public async ValueTask<bool> Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            entity.NotNull();

            return await _dbConnection.UpdateAsync(entity).ConfigureAwait(false);
        }
    }
}