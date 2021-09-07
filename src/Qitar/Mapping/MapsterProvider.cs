using Mapster;
using Qitar.Utils;
using System;
using System.Threading.Tasks;

namespace Qitar.Mapping
{
    public class MapsterProvider : IMappingProvider
    {
        private readonly MapsterMapper.IMapper _mapper;

        public MapsterProvider(TypeAdapterConfig typeAdapterConfig)
        {
            typeAdapterConfig.NotNull();
            _mapper = new MapsterMapper.Mapper(typeAdapterConfig);
        }

        public dynamic Map(object obj, Type source, Type destination)
        {
            return _mapper.Map(obj, source, destination);
        }

        public async ValueTask<T> Map<T>(object obj)
        {
            return await _mapper.From(obj).AdaptToTypeAsync<T>().ConfigureAwait(false);
        }
    }
}
