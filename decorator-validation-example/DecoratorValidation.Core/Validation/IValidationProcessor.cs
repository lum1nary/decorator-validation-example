using System.Collections.Generic;

namespace DecoratorValidation.Core
{
    public interface IValidationProcessor
    {
        IReadOnlyList<ValidationConfig> Configurations { get; }

        void Subscribe(IValidationNode node);
        void Unsubscribe(IValidationNode node);
    }
}