using System;

namespace DecoratorValidation.Core.ValidationRules
{
    public class PredicativeRule : ValidationRuleBase
    {
        private Func<IValidationNode, bool> _predicate;

        public PredicativeRule(Func<IValidationNode, bool> predicate, string message = null)
         : base(message)
        {
            _predicate = predicate;
        }

        public override IValidationResult Validate(IValidationNode node)
        {
            return _predicate(node) ? 
        }
    }
}