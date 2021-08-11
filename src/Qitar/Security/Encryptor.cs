using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Security
{
    public class Encryptor : IEncryptor
    {
        public async ValueTask<string> Decrypt(string data, string key, CancellationToken cancellationToken = default)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Convert.FromBase64String(data.Substring(0, 24));
                var transform = aes.CreateDecryptor(aes.Key, aes.IV);
                using var memoryStream = new MemoryStream(Convert.FromBase64String(data.Substring(24)));
                using var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
                using var streamReader = new StreamReader(cryptoStream);

                return await streamReader.ReadToEndAsync().ConfigureAwait(false);
            }
        }

        public async ValueTask<string> Encrypt(string data, string key, CancellationToken cancellationToken = default)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                var iv = Convert.ToBase64String(aes.IV);
                var transform = aes.CreateDecryptor(aes.Key, aes.IV);
                using var memoryStream = new MemoryStream();
                using var cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
                using (var streamWriter = new StreamWriter(cryptoStream))
                {
                    await streamWriter.WriteAsync(data.ToCharArray(), cancellationToken).ConfigureAwait(false);
                };

                return iv + Convert.ToBase64String(memoryStream.ToArray());
            }
        }
    }
}
