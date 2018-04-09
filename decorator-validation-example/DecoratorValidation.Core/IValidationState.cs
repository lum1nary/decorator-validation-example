namespace DecoratorValidation.Core
{
    public interface IValidationState
    {
        bool IsValid { get; }

        string Message { get; }
    }
}