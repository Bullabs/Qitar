using Qitar.Utils;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Cryptography
{
    internal sealed class Hasher : IHasher
    {
        public string Hash(string data)
        {
            var hash = Hash(Encoding.UTF8.GetBytes(data));
            return string.Concat(hash.Select(s => s.ToString("X2")));
        }

        public byte[] Hash(byte[] data)
        {
            data.NotNull();

            using (var sha256Hash = SHA256.Create())
            {
                return sha256Hash.ComputeHash(data);
            }
        }

        public async ValueTask<byte[]> Hash(Stream data, CancellationToken cancellationToken = default)
        {
            using (var sha256Hash = SHA256.Create())
            {
                return await sha256Hash.ComputeHashAsync(data, cancellationToken);
            }
        }
    }
}
