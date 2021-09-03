using Qitar.Utils;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
    }
}
