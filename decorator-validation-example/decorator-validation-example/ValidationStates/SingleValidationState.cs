namespace DecoratorValidation.Core
{
    public class SingleValidationState : IValidationState
    {
        public static readonly IValidationState Empty = new SingleValidationState();

        public SingleValidationState(bool isValid = false, string message = "")
        {
            IsValid = isValid;
            Message = message;
        }

        public bool IsValid { get; }
        public string Message { get; }
    }
}