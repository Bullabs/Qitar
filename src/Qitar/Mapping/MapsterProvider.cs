using System;
using System.Collections.Generic;
using System.Text;

namespace Qitar.Mapping
{
    public class MapsterProvider : IMappingProvider
    {
        public dynamic Map(object obj, Type source, Type destination)
        {
            throw new NotImplementedException();
        }

        public T Map<T>(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
