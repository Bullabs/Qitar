using Microsoft.EntityFrameworkCore.Storage;
using Qitar.Transactions;
using Qitar.Utils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Sql
{
    internal sealed class SqlTransaction : ITransaction
    {
        private IDbContextTransaction _transaction;
        private bool _disposed;

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
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _transaction = null;
                }
                _disposed = true;
            }            
        }        
    }
}
