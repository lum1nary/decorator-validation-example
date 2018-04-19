using System.Collections.Generic;

namespace DecoratorValidation.Core
{
    public interface IValidationProcessor
    {
        void ProcessNode(INodeViewModel node, IEnumerable<IValidationRule> rules);
    }
}