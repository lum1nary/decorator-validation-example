using System.Collections.Generic;

namespace DecoratorValidation.Core
{
    public interface IValidationService
    {
        IEnumerable<IValidationRule> GetRules(NodeType nodeType);

        void RegisterRules(NodeType nodeType, params IValidationRule[] rules);

        void Register(IValidationNode node);
        void Unregister(IValidationNode node);
    }
}