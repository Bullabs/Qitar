namespace Qitar.Validation
{
    public class ValidationResult : IValidationResult
    {
        public string Error { get; set; }
        public bool IsValid { get; set; }

        public ValidationResult(string error)
        {
            Error = error;
            IsValid = string.IsNullOrEmpty(error);
        }
    }
}
