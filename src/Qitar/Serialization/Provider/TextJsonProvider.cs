using Json.Abstraction;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Serialization.Provider
{
    public class TextJsonProvider : ISerializerProvider
    {
        private readonly JsonSerializerOptions _jsonOptions;

        public TextJsonProvider(IOptions<SerializerOptions> options )
        {
            var serializerOptions = options.Value;

            _jsonOptions = new JsonSerializerOptions()
            {
                WriteIndented = serializerOptions.IsIndented,
                Converters = { new JsonAbstractionConverter() }
            };
        }

        public async ValueTask<object> DeserializeAsync(Stream stream, Type type, CancellationToken cancellationToken)
        {
            return await JsonSerializer.DeserializeAsync(stream, typeof(object), _jsonOptions, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<TObject> DeserializeAsync<TObject>(Stream stream, CancellationToken cancellationToken)
        {
            return await JsonSerializer.DeserializeAsync<TObject>(stream, _jsonOptions, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask SerializeAsync<TObject>(Stream stream, TObject obj, CancellationToken cancellationToken)
        {
            await JsonSerializer.SerializeAsync(stream, obj, _jsonOptions, cancellationToken).ConfigureAwait(false);
        }
    }
}