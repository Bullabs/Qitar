namespace Qitar.Objects
{
    public interface IHaveParent
    {
        object ParentId { get; set; }
    }

    public interface IHaveParent<out T> : IHaveParent
    {
        new T ParentId { get; }
    }
}
