namespace DecoratorValidation.Core.ValidationRules
{
    public abstract class ValidationRuleBase : IValidationRule
    {
        protected string Message;

        protected ValidationRuleBase(string message = "")
        {
            Message = message;
        }

        public abstract IValidationResult Validate(IValidationNode node, IValidationService service);
    }
}