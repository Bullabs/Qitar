namespace Qitar.Mapping
{
    public interface IMapper
    {
        dynamic CreateConcreteObject(object obj);
        T Map<T>(object obj);
    }
}
