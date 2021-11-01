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
            _transaction?.Dispose();
            _transaction = null;
        }

    }
}
