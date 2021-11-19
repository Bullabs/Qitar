using System.Runtime.Serialization;

namespace Qitar.Objects.Results
{
    public class SingleResult<T> : ISingleResult<T>
    {
        [DataMember]
        public T Value { get; }

        private SingleResult(T value)
        {
            Value = value;
        }
        public static SingleResult<T> Create(T value)
        {
            return new SingleResult<T>(value);
        }
    }
}