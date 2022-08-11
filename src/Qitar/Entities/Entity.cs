using System;
using System.ComponentModel.DataAnnotations;

namespace Qitar.Entities
{
    [Serializable]
    public abstract class Entity<TKey> : IEntity<TKey>, IEquatable<Entity<TKey>> where TKey : IEquatable<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Entity<TKey> entity)
            {
                return Equals(entity);
            }
            return base.Equals(obj);
        }

        public virtual bool Equals(Entity<TKey> other)
        {
            if (other is null)
            {
                return false;
            }
            return Id.Equals(other.Id);
        }

        public override string ToString()
        {
            return $"[ENTITY: {GetType().Name}] Id = {Id}";
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }

        public static bool operator ==(Entity<TKey> x, Entity<TKey> y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Entity<TKey> x, Entity<TKey> y)
        {
            return !(x == y);
        }
    }

    [Serializable]
    public class Entity : Entity<Guid>
    {
    }
}
