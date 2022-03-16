using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qitar.Utils
{
    public static class Extentions
    {
        public static bool HasValue<T>(this T value)
        {
            return value != null;
        }

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

        public static ValueTask<T> ValueTask<T>(this T value)
        {
            return new ValueTask<T>(value);
        }

    }
}
