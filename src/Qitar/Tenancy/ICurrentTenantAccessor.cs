namespace Qitar.Tenancy
{
    public interface ICurrentTenantAccessor
    {
        ITenant CurrentTenant { get; set; }
}
}
