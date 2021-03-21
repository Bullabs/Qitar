using System;

namespace Qitar.Mapping
{
    public interface IMappingProvider
    {
        dynamic Map(object obj, Type source, Type destination);
        T Map<T>(object obj);
    }
}
