using Qitar.Objects.Results;
namespace Qitar.Validation
{
    public interface IValidationResult: IResult
    {
        string Error { get; set; }
        bool IsValid { get; set; }
    }
}