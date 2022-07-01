using Qitar.Metadata;
using System;
using System.Collections.Generic;

namespace Qitar.Messages
{
    public interface IMessageMetadata: IMetadataContainer
    {
        Guid SourceId { get; }
        Guid CorrelationId { get; }
        IReadOnlyCollection<Guid> CorrelationIds { get; }

    }
}
