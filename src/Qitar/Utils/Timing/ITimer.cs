using System;

namespace Qitar.Utils.Timing
{
    public interface ITimer
    {
        T Time<T>(Func<T> action);
        void Time(Action action);
    }
}