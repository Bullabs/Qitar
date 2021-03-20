using System;
using System.Collections.Generic;
using System.Text;

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
