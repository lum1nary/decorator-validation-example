using System.Collections.Generic;
using System.Linq;

namespace DecoratorValidation.Core
{
    public class CollectionValidationState : IValidationState
    {
        private readonly IList<IValidationState> _states;

        public CollectionValidationState(params IValidationState[] states) 
        {
            _states = new List<IValidationState>(states);
        }

        public bool IsValid => _states.All(i => i.IsValid);
        public string Message => string.Join("\n", _states.Select(i => i.Message));
    }
}