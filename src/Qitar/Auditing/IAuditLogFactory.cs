using Qitar.Entities;
using Qitar.Factories;

namespace Qitar.Auditing
{
    public interface IAuditLogFactory<TEntity> : IFactory<TEntity, IAuditLog> where TEntity : class , IEntity
    {
    }
}
