namespace DecoratorValidation.Core.ValidationRules
{
    public abstract class ValidationRuleBase : IValidationRule
    {
        protected string _message;

        protected ValidationRuleBase(string message = "")
        {
            _message = message
        }

        public abstract IValidationResult Validate(IValidationNode node);
    }
}