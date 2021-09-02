using Qitar.Objects.Audit;
using System;

namespace Qitar.Entities
{
    internal interface IAuditableEntity<out TKey> : IEntity<TKey>, IAuditable
    {
    }
    internal interface IAuditableEntity : IAuditableEntity<Guid>
    {
    }
}
