using System;
using System.Collections.Generic;

namespace Qitar.Dependencies
{
    public interface IResolver
    {
        object Resolve(Type type);
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
    }
}
