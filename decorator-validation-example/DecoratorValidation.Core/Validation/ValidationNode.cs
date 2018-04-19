using System.Collections.Generic;

namespace DecoratorValidation.Core
{
    public class ValidationNode : IValidationNode
    {
        public virtual int Depth => GetCurrentDepth(); 

        public virtual IValidationNode Parent { get; }
        public IList<IValidationNode> Children { get; } = new List<IValidationNode>();

        public INodeViewModel Node { get; }

        public IValidationResult ValidationState { get; set; }

        public ValidationNode(INodeViewModel node, IValidationNode parent)
        {
            Node = node;
            Parent = parent;
            ValidationState = ValidationResult.Empty;
        }

        private int GetCurrentDepth()
        {
            int depth = 0;

            var parent = Node.Parent;
            while (parent != null)
            {
                depth++;
                parent = parent.Parent;
            }

            return depth;
        }
    }
}