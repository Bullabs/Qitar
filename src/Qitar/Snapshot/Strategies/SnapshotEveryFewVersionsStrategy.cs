using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Snapshot.Strategies
{
    public class SnapshotEveryFewVersionsStrategy : ISnapshotStrategy
    {

        private readonly int _snapshotInterval ; 

        public SnapshotEveryFewVersionsStrategy(int snapshotInterval = 100)
        {
            _snapshotInterval = snapshotInterval;
        }

        public ValueTask<bool> ShouldCreateSnapshot(ISnapshotAggregate aggregate, CancellationToken cancellationToken = default)
        {
            var currentSnapshotVersion = aggregate.SnapshotVersion.GetValueOrDefault(_snapshotInterval);
             return new ValueTask<bool>(aggregate.Version - currentSnapshotVersion >= _snapshotInterval);
        }
    }
}
