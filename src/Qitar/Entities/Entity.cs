using Qitar.Objects;
using System;

namespace Qitar.Entities
{
    public class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; set; }

        object IIdentity.Id { get { return Id; }}
    }

    public class Entity : Entity<Guid>
    {
    }
}
