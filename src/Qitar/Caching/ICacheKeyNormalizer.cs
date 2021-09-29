namespace Qitar.Caching
{
    public interface ICacheKeyNormalizer
    {
        string NormalizeKey(string key);
    }
}
