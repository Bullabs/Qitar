using System.Threading;

namespace Qitar.Tenancy
{
    public class TenantContext<TContext> : ITenantContext, ITenantContext<TContext> where TContext : ITenant, new()
    {
        private readonly static AsyncLocal<TContext> _asyncLocalContext = new AsyncLocal<TContext>();


        public TContext CurrentTenant 
        {
            get => _asyncLocalContext.Value;
            set => _asyncLocalContext.Value = value;
        }
        ITenant ITenantContext.CurrentTenant 
        {
            get => CurrentTenant;
            set => CurrentTenant = (TContext) value ?? CurrentTenant;
        }
    }
}
