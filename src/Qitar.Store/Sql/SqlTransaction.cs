using Microsoft.EntityFrameworkCore.Storage;
using Qitar.Transactions;
using Qitar.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Sql
{
    internal sealed class SqlTransaction : ITransaction, IDisposable
    {
        private IDbContextTransaction _transaction;

        public SqlTransaction(IDbContextTransaction transaction)
        {
            _transaction = transaction.NotNull();
        }

        public async ValueTask Commit(CancellationToken cancellationToken = default)
        {
            await _transaction.CommitAsync(cancellationToken);
        }

        public async ValueTask Rollback(CancellationToken cancellationToken = default)
        {
            await _transaction.RollbackAsync(cancellationToken);
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _transaction = null;
        }
    }
}
