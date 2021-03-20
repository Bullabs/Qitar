using System;

namespace Qitar.Entities
{
    public class AuditableEntity<TKey> : Entity<TKey>, IAuditableEntity<TKey>
    {
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? ModifiedBy { get; set; }
    }
    public class AuditableEntity : AuditableEntity<Guid>
    {
    }
}
