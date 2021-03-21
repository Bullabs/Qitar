using Dapper;
using Dapper.Contrib.Extensions;
using Qitar.Entities;
using Qitar.Objects;
using Qitar.Repositories;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Dapper
{
    public class DapperRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity, IIdentity
    {
        private readonly IDbConnection _dbConnection;

        public DapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentException(nameof(dbConnection));
        }

        public async ValueTask<bool> Delete(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<TEntity> GetById(object id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<TEntity> Insert(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<bool> Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

    }
}

