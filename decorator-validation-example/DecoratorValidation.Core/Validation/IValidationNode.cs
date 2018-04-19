using System.Collections.Generic;

namespace DecoratorValidation.Core
{
    public interface IValidationNode
    {
        int Depth { get; }

        IValidationNode Parent { get; }

        IList<IValidationNode> Children { get; }

        INodeViewModel Node { get; }

        IValidationResult ValidationState { get; set; }
    }
}