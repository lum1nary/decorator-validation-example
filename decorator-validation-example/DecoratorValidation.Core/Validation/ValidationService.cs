using System.Collections.Generic;

namespace DecoratorValidation.Core
{
    public class ValidationService : IValidationService
    {
        private readonly IDictionary<NodeType, IList<IValidationRule>> _nodeRules = new Dictionary<NodeType, IList<IValidationRule>>();

        private readonly HashSet<IValidationNode> _nodes = new HashSet<IValidationNode>();

        public IEnumerable<IValidationRule> GetRules(NodeType nodeType)
        {
            return _nodeRules.TryGetValue(nodeType, out var rules) ? 
                rules : 
                new IValidationRule[0];
        }

        public void RegisterRules(NodeType nodeType, params IValidationRule[] rules)
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

        public void Register(IValidationNode node)
        {
            _nodes.Add(node);
        }

        public void Unregister(IValidationNode node)
        {
            _nodes.Remove(node);
        }
    }
}