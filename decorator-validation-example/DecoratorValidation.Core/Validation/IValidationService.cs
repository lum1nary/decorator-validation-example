using System.Collections.Generic;

namespace DecoratorValidation.Core
{
    public interface IValidationService
    {
        void RegisterRules(NodeType nodeType, params IValidationRule[] rules);

        void RegisterRules(string nodeType, params IValidationRule[] rules);

        void Validate(INodeViewModel node);
    }
}