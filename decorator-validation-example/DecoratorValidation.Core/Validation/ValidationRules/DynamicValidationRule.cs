using System;
using DecoratorValidation.Core.TreeConductors;

namespace DecoratorValidation.Core.ValidationRules
{
    public class DynamicValidationRule : IValidationRule
    {
        private readonly string _errorMessage;

        private readonly Func<IValidationNode, ITreeConductor<IValidationNode>, bool> _ruleFunc;

        public DynamicValidationRule(Func<IValidationNode, ITreeConductor<IValidationNode>, bool> ruleFunc, string errorMessage = "")
        {
            _ruleFunc = ruleFunc;
            _errorMessage = errorMessage;
        }

        public IValidationResult Validate(IValidationNode node, ITreeConductor<IValidationNode> treeConductor)
        {
            return _ruleFunc(node, treeConductor) ? 
                new ValidationResult(true) : 
                new ValidationResult(false, _errorMessage);
        }
    }
}