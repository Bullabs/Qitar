namespace Qitar.Objects.Audit
{
    public interface IAuditable<TUser> : ICreationAudit<TUser>, IModificationAudit<TUser>, IDeletionAudit<TUser>
    {
    }
    public interface IAuditable : ICreationAudit, IModificationAudit, IDeletionAudit
    {
    }
}
