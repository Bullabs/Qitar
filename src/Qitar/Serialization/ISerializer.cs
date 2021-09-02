using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Serialization
{
    public interface ISerializer
    {
        ValueTask<string> Serialize<TObject>(TObject obj, CancellationToken cancellationToken);
        ValueTask<Stream> SerializeStream<TObject>(TObject obj, CancellationToken cancellationToken);
        ValueTask<object> Deserialize(string value, Type type, CancellationToken cancellationToken);
        ValueTask<TObject> Deserialize<TObject>(byte[] valueArray, CancellationToken cancellationToken);
        ValueTask<TObject> Deserialize<TObject>(string value, CancellationToken cancellationToken);
        ValueTask<TObject> Deserialize<TObject>(Stream stream, CancellationToken cancellationToken);
        ValueTask<object> Deserialize(Stream stream, Type type, CancellationToken cancellationToken);
    }
}
