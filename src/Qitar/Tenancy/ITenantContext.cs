namespace Qitar.Tenancy
{
    public interface ITenantContext<TContext> where TContext : ITenant, new()
    {
        TContext CurrentTenant { get; set; }
    }

    public interface ITenantContext
    {
        ITenant CurrentTenant { get; set; }
    }
}
