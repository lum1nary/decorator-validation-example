using System;
using DecoratorValidation.Core.TreeConductors;

namespace DecoratorValidation.Core.ValidationRules
{
    public class DynamicValidationRule : IValidationRule
    {
        private readonly string _errorMessage;

        private readonly Func<INodeViewModel, ITreeConductor<INodeViewModel>, bool> _ruleFunc;

        public DynamicValidationRule(Func<INodeViewModel, ITreeConductor<INodeViewModel>, bool> ruleFunc, string errorMessage = "")
        {
            _ruleFunc = ruleFunc;
            _errorMessage = errorMessage;
        }

        public IValidationResult Validate(INodeViewModel node, ITreeConductor<INodeViewModel> treeConductor)
        {
            return _ruleFunc(node, treeConductor) ? 
                new ValidationResult(true) : 
                new ValidationResult(false, _errorMessage);
        }
    }
}