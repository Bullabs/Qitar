using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Cryptography
{
    public interface IHasher
    {
        string Hash(string data);
        byte[] Hash(byte[] data);
        ValueTask<byte[]> Hash(Stream data, CancellationToken cancellationToken = default);
    }
}
