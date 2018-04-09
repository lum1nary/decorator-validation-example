using System.Collections.Generic;

namespace DecoratorValidation.Core
{
    public class ValidationConfig
    {
        public NodeType NodeType { get; }

        public ValidationStyle ValidationStyle { get; }

        public IReadOnlyList<IValidationRule> ValidationRules { get; }

        public ValidationConfig(NodeType nodeType, ValidationStyle style, params IValidationRule[] rules)
        {
            NodeType = nodeType;
            ValidationStyle = style;
            ValidationRules = rules;
        }
    }
}