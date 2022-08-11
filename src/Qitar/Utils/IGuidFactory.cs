using Qitar.Factories;
using System;

namespace Qitar.Utils
{
    public interface IGuidFactory : IFactory<Guid>, IFactory<Guid,Guid>
    {
    }
}
