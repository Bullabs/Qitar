﻿using System.Threading;
using System.Threading.Tasks;

namespace Qitar.Cryptography
{
    public interface IEncryptor
    {
        ValueTask<string> Encrypt(string data, string key, CancellationToken cancellationToken = default);
        ValueTask<string> Decrypt(string data, string key, CancellationToken cancellationToken = default);
    }
}
