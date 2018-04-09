namespace DecoratorValidation.Core
{
    public interface IValidationService
    {
        void Register(IValidationNode node);
        void Unregister(IValidationNode node);

        void QueryValidation(IValidationNode root);
    }
}