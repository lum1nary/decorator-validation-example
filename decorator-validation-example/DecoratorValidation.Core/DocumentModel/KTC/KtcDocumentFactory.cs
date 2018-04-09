namespace DecoratorValidation.Core.DocumentModel.KTC
{
    public class KtcDocumentFactory : DocumentFactory
    {
        public KtcDocumentFactory(
            IDocumentNodeFactory nodeFactory,
            IDocumentHeaderFactory headerFactory,
            IDocumentBodyFactory bodyFactory) : base(nodeFactory, headerFactory, bodyFactory)
        {
        }
    }
}