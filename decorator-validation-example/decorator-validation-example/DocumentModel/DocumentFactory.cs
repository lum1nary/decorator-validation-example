namespace DecoratorValidation.Core.DocumentModel
{
    public class DocumentFactory : IDocumentFactory
    {
        protected IDocumentHeaderFactory HeaderFactory { get; }
        protected IDocumentBodyFactory BodyFactory { get; }
        protected IDocumentNodeFactory NodeFactory { get; }

        public DocumentFactory(
            IDocumentNodeFactory nodeFactory,
            IDocumentHeaderFactory headerFactory,
            IDocumentBodyFactory bodyFactory)
        {
            NodeFactory = nodeFactory;
            HeaderFactory = headerFactory;
            BodyFactory = bodyFactory;
        }

        public INodeViewModel CreateDocument()
        {
            return BuildDocument();
        }

        protected virtual INodeViewModel BuildDocument()
        {
            var doc = NodeFactory.CreateRoot();
            HeaderFactory.CreateHeader(doc);
            BodyFactory.CreateBody(doc);
            return doc;
        }
    }
}