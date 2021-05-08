namespace Qitar.Objects
{
    public interface IIdentity
    {
        object Id { get; }
    }

    public interface IIdentity<out T> : IIdentity
    {
         new T Id { get; }
         object IIdentity.Id => Id;
    }
}
