using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Serialization
{
    public interface ISerializerProvider
    {
        ValueTask SerializeAsync<TObject>(Stream stream, TObject obj, CancellationToken cancellationToken);
        ValueTask<object> DeserializeAsync(Stream stream, Type type, CancellationToken cancellationToken);
        ValueTask<TObject> DeserializeAsync<TObject>(Stream stream, CancellationToken cancellationToken);
    }
}
