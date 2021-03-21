using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Serialization
{
    public interface ISerializer
    {
        ValueTask<string> SerializeAsync<TObject>(TObject obj, CancellationToken cancellationToken);
        ValueTask<object> DeserializeAsync(string value, Type type, CancellationToken cancellationToken);
        ValueTask<TObject> DeserializeAsync<TObject>(byte[] valueArray, CancellationToken cancellationToken);
        ValueTask<TObject> DeserializeAsync<TObject>(string value, CancellationToken cancellationToken);
        ValueTask<TObject> DeserializeAsync<TObject>(Stream stream, CancellationToken cancellationToken);
        ValueTask<object> DeserializeAsync(Stream stream, Type type, CancellationToken cancellationToken);
    }
}
