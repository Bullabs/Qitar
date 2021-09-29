namespace Qitar.Caching
{
    public class CacheOptions
    {
        public int DefaultCacheTime { get; set; } = 60;
        public string KeyPrefix { get; set; }="";
    }
}
