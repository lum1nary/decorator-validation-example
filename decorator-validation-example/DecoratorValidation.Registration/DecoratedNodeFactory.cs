using Autofac;
using DecoratorValidation.Core;
using DecoratorValidation.Core.DocumentModel;

namespace DecoratorValidation.Registration
{
    public class DecoratedNodeFactory : IDocumentNodeFactory
    {
        private readonly IComponentContext _container;

        public DecoratedNodeFactory(IComponentContext container)
        {
            _container = container;
        }

        public INodeViewModel CreateRoot()
        {
            return Create(null, "document_root");
        }

        public INodeViewModel Create(INodeViewModel parent, NodeType nodeType)
        {
            return Create(parent, nodeType.ToString());
        }

        public INodeViewModel Create(INodeViewModel parent, string nodeType)
        {
            IDocumentNodeFactory factory = _container.ResolveOptionalKeyed<IDocumentNodeFactory>(nodeType);

            if (factory == null)
                factory = _container.ResolveKeyed<IDocumentNodeFactory>("default_node");

            INodeViewModel node = factory.Create(parent, nodeType);

            if(parent != null)
                parent.Children.Add(node);

            return node;
        }
    }
}