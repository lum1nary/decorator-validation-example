namespace DecoratorValidation.Core
{
    public interface IValidationNodeFactory
    {
        IValidationNode CreateRoot();

        IValidationNode Create(IValidationNode parent);
    }
}