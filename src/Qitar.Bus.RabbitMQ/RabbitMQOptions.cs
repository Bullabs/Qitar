using System;

namespace Qitar.Bus.RabbitMQ
{
    public class RabbitMQOptions : IBusOptions
    {
        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Topic { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
