namespace DecoratorValidation.Core
{
    public class ValidationNodeFactory : IValidationNodeFactory
    {
        public IValidationNode CreateRoot()
        {
            return new RootValidationNode();
        }

        public IValidationNode Create(IValidationNode parent)
        {
            return new ValidationNode(parent);
        }
    }
}