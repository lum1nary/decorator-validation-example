using System.Collections.Generic;

namespace DecoratorValidation.Core
{
    public class NullValidationService : IValidationService
    {
        public IEnumerable<IValidationRule> GetRules(NodeType nodeType)
        {
            return new List<IValidationRule>();
        }

        public void RegisterRules(NodeType nodeType, params IValidationRule[] rules)
        {
        }

        public void Register(IValidationNode node)
        {
        }

        public void Unregister(IValidationNode node)
        {
        }
    }
}