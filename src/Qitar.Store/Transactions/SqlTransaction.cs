using Qitar.Transactions;
using Qitar.Utils;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Store.Transactions
{
    public class SqlTransaction : ITransaction
    {
        private IDbTransaction _transaction;
        private bool _disposed;

        public SqlTransaction(IDbTransaction transaction)
        {
            _transaction = transaction.NotNull();
        }

        public ValueTask Commit(CancellationToken cancellationToken = default)
        {
            _transaction.Commit();
            return default;
        }

        public ValueTask Rollback(CancellationToken cancellationToken = default)
        {
            _transaction.Rollback();
            return default;
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
