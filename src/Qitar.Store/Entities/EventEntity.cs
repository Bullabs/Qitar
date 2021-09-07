using Qitar.Entities;
using System;

namespace Qitar.Store.Entities
{
    public class EventEntity : Entity
    {
        public long Version { get; set; }
        public string EventType { get; set; }
        public string Payload { get; set; }
        public DateTime TimeStamp { get; set; }
        public string User { get; set; }

    }
}
