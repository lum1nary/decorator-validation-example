using System;
using System.Collections.Generic;

namespace DecoratorValidation.Core
{
    public class ValidationService : IValidationService
    {
        private readonly HashSet<IValidationNode> _nodes = new HashSet<IValidationNode>();

        public void Register(IValidationNode node)
        {
            _nodes.Add(node);
        }

        public void Unregister(IValidationNode node)
        {
            _nodes.Remove(node);
        }

        public void QueryValidation(IValidationNode root)
        {
            throw new System.NotImplementedException();
        }
    }
}