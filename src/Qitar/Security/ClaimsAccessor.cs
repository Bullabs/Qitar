using Qitar.Serialization;
using Qitar.Utils;
using System.Linq;
using System.Security.Claims;
using System.Threading;

namespace Qitar.Security
{
    public class ClaimsAccessor : IClaimsAccessor
    {
        private readonly AsyncLocal<IUser> _asyncLocalAccessor;

        public ClaimsAccessor(IPrincipalAccessor principalAccessor, ISerializer serializer)
        {
            principalAccessor.NotNull();

            var userJson = principalAccessor.Principal?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.UserData)?.Value;

            if (!string.IsNullOrEmpty(userJson))
            {
                var user = serializer.Deserialize<IUser>(userJson, default).Result;
                _asyncLocalAccessor.Value = user;
            }
        }

        public IUser CurrentUser
        {
            get => _asyncLocalAccessor.Value;
        }
    }
}
