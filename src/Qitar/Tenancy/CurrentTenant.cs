using Qitar.Utils;
using System;

namespace Qitar.Tenancy
{
    public class CurrentTenant : ICurrentTenant
    {
        private readonly ICurrentTenantAccessor _accessor;

        public CurrentTenant(ICurrentTenantAccessor accessor)
        {
            _accessor = accessor.NotNull();
        }

        public Guid? Id => _accessor.CurrentTenant?.Id;
        public string Identifier => _accessor.CurrentTenant?.Identifier;
        public string Name => _accessor.CurrentTenant?.Name;
        public string ConnectionString => _accessor.CurrentTenant?.ConnectionString;
        public int ConnectionType => _accessor.CurrentTenant.ConnectionType;
        public string Culture=> _accessor.CurrentTenant?.Culture;
        public string TimeZone=> _accessor.CurrentTenant?.TimeZone;
    }
}
