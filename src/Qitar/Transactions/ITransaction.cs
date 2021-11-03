using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Transactions
{
    public interface ITransaction : IDisposable
    {
        ValueTask Commit(CancellationToken cancellationToken = default);
        ValueTask Rollback(CancellationToken cancellationToken = default);
    }
}
