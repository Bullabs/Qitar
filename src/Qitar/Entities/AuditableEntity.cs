using System;

namespace Qitar.Entities
{
    public abstract class AuditableEntity<TKey> : Entity<TKey>, IAuditableEntity<TKey> where TKey : IEquatable<TKey>
    {
        public Guid CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Guid DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class AuditableEntity : AuditableEntity<Guid>
    {
    }
}
