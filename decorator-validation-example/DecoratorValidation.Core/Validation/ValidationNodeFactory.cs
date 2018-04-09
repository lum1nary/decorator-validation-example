namespace DecoratorValidation.Core
{
    public class ValidationNodeFactory : IValidationNodeFactory
    {
        public IValidationNode CreateRoot()
        {
            return Create(null);
        }

        public IValidationNode Create(IValidationNode parent)
        {
            return new ValidationNode(parent);
        }
    }
}