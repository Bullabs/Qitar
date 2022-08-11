using System;

namespace Qitar.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
    public interface IEntity : IEntity<Guid>
    {
    }
}
