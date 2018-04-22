using DecoratorValidation.Core.TreeConductors;

namespace DecoratorValidation.Core.ValidationRules
{
    public class NotEmptyRule : IValidationRule
    {
        public IValidationResult Validate(INodeViewModel node, ITreeConductor<INodeViewModel> conductor)
        {
            return string.IsNullOrEmpty(node.Value) ? 
                new ValidationResult(false, "Value should nod be empty") : 
                ValidationResult.Valid;
        }
    }
}