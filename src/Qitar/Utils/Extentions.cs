using System;
using System.Collections.Generic;

namespace Qitar.Utils
{
    public static class Extentions
    {
        public static T NotNull<T>(this T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return value;
        }

        public static bool AddIfNotContains<T>(this ICollection<T> source, T item)
        {
            source.NotNull();

            if (source.Contains(item))
            {
                return false;
            }

            source.Add(item);
            return true;
        }
    }
}
