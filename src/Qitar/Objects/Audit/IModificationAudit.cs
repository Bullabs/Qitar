using System;

namespace Qitar.Objects.Audit
{
    public interface IModificationAudit<TKey>
    {
        TKey ModifiedBy { get; set; }
        DateTime? ModifiedOn { get; set; }
    }
    public interface IModificationAudit: IModificationAudit<Guid>
    {
    }
}
