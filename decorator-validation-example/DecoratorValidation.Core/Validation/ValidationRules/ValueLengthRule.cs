using System;

namespace DecoratorValidation.Core.ValidationRules
{
    public class ValueLengthRule : IValidationRule
    {
        private readonly int _min;
        private readonly int _max;

        public ValueLengthRule(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public IValidationResult Validate(IValidationNode node, IValidationService service)
        {
            var length = node.Node.Value.Length;
            return (length >= _min && length <= _max)
                ? ValidationResult.Valid
                : new ValidationResult(false, "Value length is not in allowed range");
        }
    }
}