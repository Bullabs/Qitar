using System;

namespace Qitar.Entities
{
    public interface IEntity<TKey>
    {
    }
    public interface IEntity : IEntity<Guid>
    {
    }
}
