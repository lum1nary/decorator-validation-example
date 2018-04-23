using DecoratorValidation.Core.DocumentModel;

namespace DecoratorValidation.Core
{
    public class NodeFactoryIntDecorator : IDocumentNodeFactory
    {
        private readonly IDocumentNodeFactory _decoratedFactory;

        public NodeFactoryIntDecorator(
            IDocumentNodeFactory decoratedFactory)
        {
            _decoratedFactory = decoratedFactory;
        }

        public INodeViewModel CreateRoot()
        {
            var root = _decoratedFactory.CreateRoot();
            return new NodeIntDecorator(root);
        }

        public INodeViewModel Create(INodeViewModel parent, NodeType nodeType)
        {
            return Create(parent, nodeType.ToString());
        }

        public INodeViewModel Create(INodeViewModel parent, string nodeType)
        {
            var node = _decoratedFactory.Create(parent, nodeType);
            var result = new NodeIntDecorator(node);

            return result;
        }
    }
}