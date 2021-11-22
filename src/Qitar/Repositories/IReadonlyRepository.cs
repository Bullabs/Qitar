using Qitar.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Repositories
{
    public interface IReadonlyRepository<TEntity> : IRepository where TEntity : class, IEntity
    {
        ValueTask<TEntity> GetById(object id, CancellationToken cancellationToken = default);
    }
}
