using System;

namespace Qitar.Objects.Audit
{
    public interface ICreationAudit<TKey>
    {
        TKey CreatedBy { get; }
        DateTime? CreatedOn{ get; }
    }
    public interface ICreationAudit : ICreationAudit<Guid>
    {
    }
}
