namespace DecoratorValidation.Core
{
    public interface IValidationService
    { 
        IValidationNode Root { get; }

        IValidationNode CreateNode(IValidationNode parent);

        void QueryValidation(IValidationNode root);

        void Initialize();
    }
}