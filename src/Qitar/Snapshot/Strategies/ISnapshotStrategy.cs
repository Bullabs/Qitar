using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Snapshot.Strategies
{
    public interface ISnapshotStrategy
    {
        ValueTask<bool> ShouldCreateSnapshot(ISnapshotAggregate aggregate, CancellationToken cancellationToken=default);
    }
}
