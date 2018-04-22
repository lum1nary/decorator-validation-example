namespace DecoratorValidation.Core.DocumentModel
{
    public class DocumentNodeFactory : IDocumentNodeFactory
    {
        public INodeViewModel CreateRoot()
        {
            return Create(null, NodeType.KtcDocument.ToString());
        }

        public INodeViewModel Create(INodeViewModel parent, NodeType nodeType)
        {
            return Create(parent, nodeType.ToString());
        }

        public INodeViewModel Create(INodeViewModel parent, string nodeType)
        {
            var result = new DocumentNodeViewModel(parent, nodeType);

            return result;
        }
    }
}