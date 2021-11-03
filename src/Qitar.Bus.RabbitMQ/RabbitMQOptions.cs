namespace Qitar.Bus.RabbitMQ
{
    public class RabbitMQOptions : IBusOptions
    {
        public string ConnectionString { get; set; }
        public string TopicPrefix { get; set; }
    }
}
