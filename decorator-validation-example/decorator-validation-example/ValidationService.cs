using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace DecoratorValidation.Core
{
    public class ValidationService : IValidationService
    {
        private readonly IValidationNodeFactory _nodeFactory;

        public ValidationService(IValidationNodeFactory nodeFactory)
        {
            _nodeFactory = nodeFactory;
        }

        public void Initialize()
        {
            Root = _nodeFactory.CreateRoot();
        }

        public IValidationNode Root { get; private set; }

        public IValidationNode CreateNode(IValidationNode parent)
        {
            return _nodeFactory.Create(parent);
        }

        public IValidationNode DestroyNode(IValidationNode node)
        {
            return null;
        }


        public void QueryValidation(IValidationNode root)
        {
            throw new System.NotImplementedException();
        }
    }
}