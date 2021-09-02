using Confluent.Kafka;
using System;

namespace Qitar.Bus.Kafka
{
    public class KafkaKeySerializer : ISerializer<Guid>
    {
        public byte[] Serialize(Guid data, SerializationContext context)
        {
            return data.ToByteArray();
        }
    }
}
