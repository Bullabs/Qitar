namespace Qitar.Validation
{
    public class ValidationResponse : IValidationResponse
    {
        public string Error { get; set; }
        public bool IsValid { get; set; }

        public ValidationResponse(string error)
        {
            Error = error;
            IsValid = string.IsNullOrEmpty(error);
        }
    }
}
