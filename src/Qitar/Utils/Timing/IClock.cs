using System;

namespace Qitar.Utils.Timing
{
    public interface IClock
    {
        DateTime Now { get; }
        DateTime Normalize(DateTime dateTime);
    }
}