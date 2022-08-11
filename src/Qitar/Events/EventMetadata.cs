using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Qitar.Events
{
    public class EventMetadata : IEventMetadata
    {
        public string this[string key] => throw new NotImplementedException();

        public Guid EventId => throw new NotImplementedException();

        public string EventName => throw new NotImplementedException();

        public int EventVersion => throw new NotImplementedException();

        public DateTimeOffset TimeStamp => throw new NotImplementedException();

        public string AggregateId => throw new NotImplementedException();

        public Guid SourceId => throw new NotImplementedException();

        public Guid CorrelationId => throw new NotImplementedException();

        public IReadOnlyCollection<Guid> CorrelationIds => throw new NotImplementedException();

        public IEnumerable<string> Keys => throw new NotImplementedException();

        public IEnumerable<string> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
