using Qitar.Entities;
using System;


namespace Qitar.Auditing
{
    [Serializable]
    public abstract class AuditLog<TKey> : Entity<TKey>, IAuditLog<TKey> where TKey : IEquatable<TKey>
    {
        public string EventType { get; set; }
        public string TableName { get; set; }
        public TKey PrimaryKey { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public TKey CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }

    [Serializable]
    public class AuditLog : AuditLog<Guid>, IAuditLog
    {
    }
}
