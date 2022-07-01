using Qitar.Utils;
using System;

namespace Qitar.Security
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IClaimsAccessor _claimsAccessor;

        public CurrentUser(IClaimsAccessor claimsAccessor)
        {
            _claimsAccessor = claimsAccessor.NotNull();
        }

        public Guid Id => _claimsAccessor.CurrentUser.Id;
        public string UserName => _claimsAccessor.CurrentUser.UserName;

        public string Email => _claimsAccessor.CurrentUser.Email;

        public bool IsAuthenticated => throw new NotImplementedException();

        public string[] Roles => _claimsAccessor.CurrentUser.Roles;
    }
}
