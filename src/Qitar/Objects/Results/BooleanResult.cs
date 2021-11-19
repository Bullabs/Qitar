namespace Qitar.Objects.Results
{
    public class BooleanResult : IBooleanResult
    {
        public bool Value { get; }

        private BooleanResult(bool value)
        {
            Value = value;
        }

        public static BooleanResult Create(bool value)
        {
            return new BooleanResult(value);
        }
    }
}
