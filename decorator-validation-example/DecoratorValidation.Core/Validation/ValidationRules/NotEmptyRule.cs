using DecoratorValidation.Core.TreeConductors;

namespace DecoratorValidation.Core.ValidationRules
{
    public class NotEmptyRule : IValidationRule
    {
        public IValidationResult Validate(IValidationNode node, ITreeConductor<IValidationNode> conductor)
        {
            return string.IsNullOrEmpty(node.Node.Value) ? 
                new ValidationResult(false, "Value should nod be empty") : 
                ValidationResult.Valid;
        }
    }
}