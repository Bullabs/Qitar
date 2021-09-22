using System.Threading;

namespace Qitar.Tenancy
{
    public class CurrentTenantAccessor : ICurrentTenantAccessor
    {
        private readonly AsyncLocal<ITenant> _asyncLocalAccessor;

        public CurrentTenantAccessor()
        {
            _asyncLocalAccessor = new AsyncLocal<ITenant>();
        }

        public ITenant CurrentTenant
        {
            get => _asyncLocalAccessor.Value;
            set => _asyncLocalAccessor.Value = value;
        }
    }
}
