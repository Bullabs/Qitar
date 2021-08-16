using System;

namespace Qitar.Mapping
{
    public class Mapper : IMapper
    {
        private readonly IMappingProvider _mappingProvider;

        public Mapper(IMappingProvider mappingProvider)
        {
            _mappingProvider = mappingProvider ?? throw new ArgumentNullException(nameof(mappingProvider));
        }

        public dynamic CreateConcreteObject(object obj)
        {
            var type = obj.GetType();
            return _mappingProvider.Map(obj, type, type);
        }

        public T Map<T>(object obj)
        {
            return _mappingProvider.Map<T>(obj);
        }
    }
}
