using Qitar.Aggregate;

namespace Qitar.Snapshot
{
    public interface ISnapshotAggregate : IAggregate
    {
        int? SnapshotVersion { get; }
    }
}
