using System.Collections.Generic;

namespace DecoratorValidation.Core
{
    public interface IValidationNode : IDecoratedNode
    {
        int Depth { get; }

        IValidationResult ValidationState { get; set; }
    }
}