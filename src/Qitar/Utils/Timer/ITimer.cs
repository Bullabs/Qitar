using System;
using System.Collections.Generic;
using System.Text;

namespace Qitar.Utils.Timer
{
    public interface ITimer
    {
        T Time<T>(Func<T> action);
        void Time(Action action);
    }
}
