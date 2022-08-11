using System.Threading.Tasks;

namespace Qitar.Factories
{
    public interface IFactory
    {
    }

    public interface IFactory<TValue> : IFactory
    {
        ValueTask<TValue> Create();
    }
    public interface IFactory<in TParam1, TValue> : IFactory
    {
        ValueTask<TValue> Create(TParam1 param);
    }

    public interface IFactory<in TParam1, in TParam2, TValue> : IFactory
    {
        ValueTask<TValue> Create(TParam1 param1, TParam2 param2);
    }

    public interface IFactory<in TParam1, in TParam2, in TParam3, TValue> : IFactory
    {
        ValueTask<TValue> Create(TParam1 param1, TParam2 param2, TParam3 param3);
    }

    public interface IFactory<in TParam1, in TParam2, in TParam3, in TParam4, TValue> : IFactory
    {
        ValueTask<TValue> Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4);
    }

    public interface IFactory<in TParam1, in TParam2, in TParam3, in TParam4, in TParam5, TValue> : IFactory
    {
        ValueTask<TValue> Create(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);
    }
}
