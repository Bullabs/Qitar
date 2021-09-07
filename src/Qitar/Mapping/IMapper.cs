using System.Threading.Tasks;

namespace Qitar.Mapping
{
    public interface IMapper
    {
        dynamic CreateConcreteObject(object obj);
        ValueTask<T> Map<T>(object obj);
    }
}
