using System.Collections.Generic;

namespace DecoratorValidation.Core
{
    public class ValidationService : IValidationService
    {
        private readonly IDictionary<string, IList<IValidationRule>> _nodeRules = new Dictionary<string, IList<IValidationRule>>();

        private readonly IValidationProcessor _validationProcessor;

        public ValidationService(IValidationProcessor validationProcessor)
        {
            _validationProcessor = validationProcessor;
        }

        private IEnumerable<IValidationRule> GetRules(string nodeType)
        {
            return _nodeRules.TryGetValue(nodeType, out var rules) ? 
                rules : 
                new IValidationRule[0];
        }

        public void RegisterRules(NodeType nodeType, params IValidationRule[] rules)
        {
            RegisterRules(nodeType.ToString(), rules);
        }

        public void RegisterRules(string nodeType, params IValidationRule[] rules)
        {
            IList<IValidationRule> existingRules;
            if (_nodeRules.TryGetValue(nodeType, out existingRules))
            {
                foreach (var rule in rules)
                {
                    existingRules.Add(rule);
                }

                return;
            }

            existingRules = new List<IValidationRule>(rules);
            _nodeRules.Add(nodeType, existingRules);
        }

        public void Validate(INodeViewModel node)
        {
            _validationProcessor.ProcessNode(node, GetRules(node.NodeType));
        }
    }
}