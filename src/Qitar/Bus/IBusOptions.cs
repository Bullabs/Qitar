namespace Qitar.Bus
{
    public interface IBusOptions
    {
        string ConnectionString { get; set; }
        string Topic { get; set; }
    }
}
