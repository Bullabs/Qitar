using System;
using System.Threading.Tasks;

namespace Qitar.Mapping
{
    public interface IMappingProvider
    {
        dynamic Map(object obj, Type source, Type destination);
        ValueTask<T> Map<T>(object obj);
    }
}
