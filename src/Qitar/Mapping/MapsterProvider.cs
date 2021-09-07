using Mapster;
using System;

namespace Qitar.Mapping
{
    public class MapsterProvider : IMappingProvider
    {
        private readonly TypeAdapterConfig _typeAdapterConfig;
        private readonly MapsterMapper.IMapper _mapper;

        public MapsterProvider(TypeAdapterConfig typeAdapterConfig)
        {
            _typeAdapterConfig = typeAdapterConfig ?? throw new ArgumentNullException(nameof(typeAdapterConfig));
            _mapper = new MapsterMapper.Mapper(typeAdapterConfig);
        }

        public dynamic Map(object obj, Type source, Type destination)
        {
            return _mapper.Map(obj, source, destination);
        }

        public T Map<T>(object obj)
        {
            return _mapper.Map<T>(obj);
        }
    }
}
