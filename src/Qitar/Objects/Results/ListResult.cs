using System.Collections.Generic;

namespace Qitar.Objects.Results
{
    public class ListResult<T> : IListResult<T>
    {
        public IList<T> Values { get; }

        private ListResult(IList<T> values)
        {
            Values = values;
        }
        public static ListResult<T> Create(IList<T> values)
        {
            if (values == null)
                values = new List<T>();

            return new ListResult<T>(values);
        }
    }
}
