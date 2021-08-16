using System;

namespace Qitar.Entities
{
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; set; }
    }

    public class Entity : Entity<Guid>
    {
    }
}
