using Qitar.Utils;
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

        public async ValueTask<object> Deserialize(string value, Type type, CancellationToken cancellationToken)
        {
            value.NotNull();
            type.NotNull();

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(value));

            return await _provider.DeserializeAsync(stream, type, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<TObject> Deserialize<TObject>(string value, CancellationToken cancellationToken)
        {
            value.NotNull();

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(value));

            return await _provider.DeserializeAsync<TObject>(stream, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<TObject> Deserialize<TObject>(Stream stream, CancellationToken cancellationToken)
        {
            stream.NotNull();

            return await _provider.DeserializeAsync<TObject>(stream, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<object> Deserialize(Stream stream, Type type, CancellationToken cancellationToken)
        {
            stream.NotNull();

            return await _provider.DeserializeAsync(stream, type, cancellationToken).ConfigureAwait(false);
        }

        public async ValueTask<TObject> Deserialize<TObject>(byte[] valueArray, CancellationToken cancellationToken)
        {
            valueArray.NotNull();

            var stream = new MemoryStream(valueArray);

            try
            {
                return await _provider.DeserializeAsync<TObject>(stream, cancellationToken).ConfigureAwait(false);
            }
            finally
            {
                await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
                await stream.DisposeAsync().ConfigureAwait(false);
            }
        }

        public async ValueTask<string> Serialize<TObject>(TObject obj, CancellationToken cancellationToken)
        {
            var stream = (MemoryStream) await SerializeStream(obj, cancellationToken).ConfigureAwait(false);

            return Encoding.UTF8.GetString((stream).ToArray());
        }

        public async ValueTask<Stream> SerializeStream<TObject>(TObject obj, CancellationToken cancellationToken)
        {
            obj.NotNull();

            var stream = new MemoryStream();

            try
            {
                await _provider.SerializeAsync(stream, obj, cancellationToken).ConfigureAwait(false);
                return stream;
            }
            finally
            {
                await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
                await stream.DisposeAsync().ConfigureAwait(false);
            }
        }
    }
}
