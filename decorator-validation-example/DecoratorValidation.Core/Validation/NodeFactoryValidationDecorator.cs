﻿using DecoratorValidation.Core.DocumentModel;

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
            return new NodeValidationDecorator(new ValidationNode(root, null), _service);
        }

        public INodeViewModel Create(INodeViewModel parent, NodeType nodeType)
        {
            var actualParent = (IValidationNode) parent;
            var node = _decoratedFactory.Create(parent, nodeType);
            var result = new NodeValidationDecorator(new ValidationNode(node, actualParent), _service);

            actualParent.Children.Add(result);

            return result;
        }
    }
}