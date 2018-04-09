namespace DecoratorValidation.Core
{
    public class ValidationResult : IValidationResult
    {
        public static readonly IValidationResult Empty = new ValidationResult();

        public ValidationResult(bool isValid = false, string message = "")
        {
            IsValid = isValid;
            Message = message;
        }

        public bool IsValid { get; }
        public string Message { get; }
    }
}