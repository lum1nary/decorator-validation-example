using System.Collections.Generic;
using System.Linq;
using DecoratorValidation.Core.TreeConductors;

namespace DecoratorValidation.Core
{
    public class ValidationProcessor : IValidationProcessor
    {
        private readonly ITreeConductor<IValidationNode> _treeConductor;

        public ValidationProcessor(ITreeConductor<IValidationNode> treeConductor)
        {
            _treeConductor = treeConductor;
        }

        public void ProcessNode(INodeViewModel node, IEnumerable<IValidationRule> rules)
        {
            var validNode = node as IValidationNode;
            if (validNode == null)
                return;

            var results = rules.Select(rule => rule.Validate(validNode, _treeConductor)).ToArray();

            validNode.ValidationState = new CollectionValidationResult(results);
        }
    }
}