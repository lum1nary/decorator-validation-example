using System.Collections.Generic;

namespace DecoratorValidation.Core.DocumentModel
{
    public class KtcDocumentHeaderFactory : IDocumentHeaderFactory
    {
        private readonly IDocumentNodeFactory _nodeFactory;

        public KtcDocumentHeaderFactory(IDocumentNodeFactory nodeFactory)
        {
            _nodeFactory = nodeFactory;
        }

        public INodeViewModel CreateHeader(INodeViewModel doc)
        {
            var fields = new List<INodeViewModel>();
            var header = _nodeFactory.Create(doc, NodeType.DocumentHeader);
            fields.Add(_nodeFactory.Create(header, NodeType.DocumentNumber));
            fields.Add(_nodeFactory.Create(header, NodeType.ProductChipher));
            fields.Add(_nodeFactory.Create(header, NodeType.ArrayChipher));
            fields.Add(_nodeFactory.Create(header, NodeType.Kc));
            fields.Add(_nodeFactory.Create(header, NodeType.DocumentDate));

            return header;
        }
    }
}