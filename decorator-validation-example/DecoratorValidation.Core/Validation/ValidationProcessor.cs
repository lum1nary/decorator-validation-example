using System.Collections.Generic;
using System.Linq;
using DecoratorValidation.Core.DocumentModel;
using DecoratorValidation.Core.TreeConductors;

namespace DecoratorValidation.Core
{
    public class ValidationProcessor : IValidationProcessor
    {
        private readonly ITreeConductor<INodeViewModel> _treeConductor;

        public ValidationProcessor(ITreeConductor<INodeViewModel> treeConductor)
        {
            _treeConductor = treeConductor;
        }

        public void ProcessNode(INodeViewModel node, IEnumerable<IValidationRule> rules)
        {
            var validNode = node.As<NodeValidationDecorator>();
            if (validNode == null)
                return;

            var results = rules.Select(rule => rule.Validate(node, _treeConductor)).ToArray();

            validNode.ValidationState = new CollectionValidationResult(results);
        }
    }
}