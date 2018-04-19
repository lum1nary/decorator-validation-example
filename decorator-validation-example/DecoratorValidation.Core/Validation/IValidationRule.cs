using DecoratorValidation.Core.TreeConductors;

namespace DecoratorValidation.Core
{
    public interface IValidationRule
    {
        IValidationResult Validate(IValidationNode node, ITreeConductor<IValidationNode> treeConductor);
    }
}