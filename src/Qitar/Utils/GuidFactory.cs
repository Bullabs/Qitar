using Qitar.Cryptography;
using Qitar.Security;
using Qitar.Tenancy;
using System;

namespace Qitar.Utils
{
    internal class GuidFactory : IGuidFactory
    {
        private readonly ICurrentTenant _currentTenant;
        private readonly ICurrentUser _currentUser;
        private readonly IHasher _hasher;

        public GuidFactory(IHasher hasher, ICurrentTenant currentTenant, ICurrentUser currentUser)
        {
            _hasher = hasher.NotNull();
            _currentTenant = currentTenant.NotNull();
            _currentUser = currentUser.NotNull();
        }

        public Guid Create(Guid sourceId)
        {
            var uidBytes = Guid.NewGuid().ToByteArray();
            var tenateBytes = _currentTenant.Id.ToByteArray();
            var userBytes = _currentUser.Id.ToByteArray();
            var souriceByte = (sourceId != Guid.Empty) ? sourceId.ToByteArray() : Array.Empty<byte>();

            var identity = GuidFromBytes(tenateBytes, userBytes).ToByteArray();
            var uid = GuidFromBytes(uidBytes, souriceByte).ToByteArray();

            return new Guid(
                    new[]
                    {
                        uid[0], uid[1], uid[2], uid[3],
                        uid[4], uid[5],
                        uid[6], (byte)(0xc0 | (0xf & uid[7])),
                        identity[1], identity[0],
                        identity[7], identity[6], identity[5], identity[4], identity[3], identity[2]
                    });
        }

        public Guid Create()
        {
            return Create(Guid.Empty);
        }

        private Guid GuidFromBytes(byte[] a, byte[] b)
        {
            var combinedBytes = new byte[a.Length + b.Length];

            Buffer.BlockCopy(a, 0, combinedBytes, 0, a.Length);
            Buffer.BlockCopy(b, 0, combinedBytes, 0, b.Length);

            var hash = _hasher.Hash(combinedBytes);

            var newGuid = new byte[16];
            Array.Copy(hash, 0, newGuid, 0, 16);
            newGuid[6] = (byte)((newGuid[6] & 0x0F) | (5 << 4));
            newGuid[8] = (byte)((newGuid[8] & 0x3F) | 0x80);

            SwapByteOrder(newGuid);
            return new Guid(newGuid);

        }

        private static void SwapByteOrder(byte[] guid)
        {
            SwapBytes(guid, 0, 3);
            SwapBytes(guid, 1, 2);
            SwapBytes(guid, 4, 5);
            SwapBytes(guid, 6, 7);
        }

        private static void SwapBytes(byte[] guid, int left, int right)
        {
            var temp = guid[left];
            guid[left] = guid[right];
            guid[right] = temp;
        }
    }
}
