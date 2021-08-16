using System;

namespace Qitar.Objects.Audit
{
    public interface IAuditable
    {
        DateTime CreatedOn { get; set; }
        int? CreatedBy { get; set; }
        DateTime? ModifiedOn { get; set; }
        int? ModifiedBy { get; set; }
    }
}
