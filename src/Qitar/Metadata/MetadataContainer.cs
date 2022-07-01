using System.Collections.Generic;
using System.Linq;

namespace Qitar.Metadata
{
    internal class MetadataContainer : Dictionary<string,string>, IMetadataContainer
    {
        public MetadataContainer()
        {
        }

        public MetadataContainer(IDictionary<string,string> keyValuePairs) 
            : base(keyValuePairs)
        {
        }

        public MetadataContainer(IEnumerable<KeyValuePair<string, string>> keyValuePairs) 
            : base(keyValuePairs.ToDictionary(kv => kv.Key, kv => kv.Value))
        {
        }

    }
}
