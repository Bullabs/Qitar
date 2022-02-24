using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Snapshot
{
    public interface ISnapshotHandler<TEntity, T> where T : ISnapshot
    {
        ValueTask Apply(TEntity entity, CancellationToken cancellationToken = default);
    }
}
