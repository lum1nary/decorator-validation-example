using System.Collections.Generic;

namespace DecoratorValidation.Core
{
    public class ValidationNode : IValidationNode
    {
        public virtual int Depth => Parent.Depth + 1;

        public virtual IValidationNode Parent { get; }
        public IList<IValidationNode> Children { get; } = new List<IValidationNode>();

        public INodeViewModel Node { get; private set; }

        public IValidationState ValidationState { get; protected set; }

        public ValidationNode(IValidationNode parent)
        {
            Parent = parent;
        }

        public void Initialize(INodeViewModel node)
        {
            Node = node;
            ValidationState = SingleValidationState.Empty;
        }
    }
}