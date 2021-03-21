using Qitar.Objects;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Repositories
{
    public interface IReadonlyRepository<TEntity> where TEntity : class, IIdentity
    {
        ValueTask<TEntity> GetById(object id, CancellationToken cancellationToken = default);
    }
}
