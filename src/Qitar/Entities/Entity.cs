using System;

namespace Qitar.Entities
{
    [Serializable]
    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; set; }
        public override string ToString()
        {
            return $"[ENTITY: {GetType().Name}] Id = {Id}";
        }

    }

    [Serializable]
    public class Entity : Entity<Guid>
    {
    }
}
