using Qitar.Objects;
using System;

namespace Qitar.Entities
{
    public interface IEntity<out TKey> : IIdentity<TKey>
    {
    }
    public interface IEntity : IEntity<Guid>
    {
    }
}
