using System;

namespace Qitar.Objects.Audit
{
    public interface IDeletionAudit<TKey>
    {
        TKey DeletedBy { get; set; }
        DateTime? DeletedOn { get; set; }
        bool IsDeleted { get; set; }

    }
    public interface IDeletionAudit: IDeletionAudit<Guid>
    {
    }
}
