using System;
using System.Threading.Tasks;

namespace Qitar.Lifecycle
{
    public interface ITransaction : IDisposable
    {
        ValueTask Commit();
        ValueTask Rollback();
    }
}
