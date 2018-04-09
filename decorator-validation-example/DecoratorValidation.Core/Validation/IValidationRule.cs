namespace DecoratorValidation.Core
{
    public interface IValidationRule
    {
        IValidationResult Validate(IValidationNode node);
    }
}