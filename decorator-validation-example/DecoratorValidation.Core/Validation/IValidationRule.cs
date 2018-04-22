using DecoratorValidation.Core.TreeConductors;

namespace DecoratorValidation.Core
{
    public interface IValidationRule
    {
        IValidationResult Validate(INodeViewModel node, ITreeConductor<INodeViewModel> treeConductor);
    }
}