using Qitar.Entities;
using Qitar.Objects.Audit;
using System;

namespace Qitar.Auditing
{
    public interface IAuditLog<TKey> : IEntity<TKey>, ICreationAudit<TKey>
    {
        string EventType { get; set; }
        string TableName { get; set; }
        public TKey PrimaryKey { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
    }
    public interface IAuditLog : IAuditLog<Guid>
    {
    }
}
