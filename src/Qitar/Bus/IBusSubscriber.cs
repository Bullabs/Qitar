using System;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Bus
{
    public interface IBusSubscriber
    {
        Type Type { get; set; }
        Func<object, CancellationToken, ValueTask> Action { get; set; }
    }
}
