using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Serialization
{
    public class Serializer : ISerializer
    {
        private readonly ISerializerProvider _provider;

        public Serializer(ISerializerProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public async ValueTask<object> DeserializeAsync(string value, Type type, CancellationToken cancellationToken)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Deserialize string is null");
            }

            if (type == null)
            {
                throw new ArgumentNullException("Deserialize type is null");
            }

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(value));

            return await _provider.DeserializeAsync(stream, type, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<TObject> DeserializeAsync<TObject>(string value, CancellationToken cancellationToken)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Deserialize string is null");
            }

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(value));

            return await _provider.DeserializeAsync<TObject>(stream, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<TObject> DeserializeAsync<TObject>(Stream stream, CancellationToken cancellationToken)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("Deserialize stream is null");
            }

            return await _provider.DeserializeAsync<TObject>(stream, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<object> DeserializeAsync(Stream stream, Type type, CancellationToken cancellationToken)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("Deserialize stream is null");
            }

            return await _provider.DeserializeAsync(stream, type, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<TObject> DeserializeAsync<TObject>(byte[] valueArray, CancellationToken cancellationToken)
        {
            if (valueArray == null)
            {
                throw new ArgumentNullException("Deserialize byte array is null");
            }

            using var stream = new MemoryStream(valueArray);
            return await _provider.DeserializeAsync<TObject>(stream, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<string> SerializeAsync<TObject>(TObject obj, CancellationToken cancellationToken)
        {
            var stream = (MemoryStream) await SerializeStreamAsync(obj, cancellationToken).ConfigureAwait(false);

            return Encoding.UTF8.GetString((stream).ToArray());
        }

        public async ValueTask<Stream> SerializeStreamAsync<TObject>(TObject obj, CancellationToken cancellationToken)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            using var stream = new MemoryStream();
            await _provider.SerializeAsync(stream, obj, cancellationToken);
            return stream;
        }
    }
}
