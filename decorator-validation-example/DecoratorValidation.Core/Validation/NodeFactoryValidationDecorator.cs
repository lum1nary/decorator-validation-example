using DecoratorValidation.Core.DocumentModel;

namespace DecoratorValidation.Core
{
    public class NodeFactoryValidationDecorator : IDocumentNodeFactory
    {
        private readonly IDocumentNodeFactory _decoratedFactory;
        private readonly IValidationService _service;

        public NodeFactoryValidationDecorator(
            IDocumentNodeFactory decoratedFactory,
            IValidationService service)
        {
            _decoratedFactory = decoratedFactory;
            _service = service;
        }

        public INodeViewModel CreateRoot()
        {
            var root = _decoratedFactory.CreateRoot();
            return new NodeValidationDecorator(root, _service);
        }

        public INodeViewModel Create(INodeViewModel parent, NodeType nodeType)
        {
            return Create(parent, nodeType.ToString());
        }

        public INodeViewModel Create(INodeViewModel parent, string nodeType)
        {
            var node = _decoratedFactory.Create(parent, nodeType);
            var result = new NodeValidationDecorator(node, _service);

            return result;
        }
    }
}