using System.Collections.Generic;
using System.Linq;

namespace DecoratorValidation.Core
{
    public class CollectionValidationResult : IValidationResult
    {
        private readonly IList<IValidationResult> _results;

        public CollectionValidationResult(params IValidationResult[] results) 
        {
            _results = new List<IValidationResult>(results);
        }

        public bool IsValid => _results.All(i => i.IsValid);
        public string Message => string.Join("\n", _results.Select(i => i.Message));
    }
}