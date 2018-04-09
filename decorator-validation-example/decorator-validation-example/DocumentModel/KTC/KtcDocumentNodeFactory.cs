namespace DecoratorValidation.Core.DocumentModel
{
    public class KtcDocumentNodeFactory : IDocumentNodeFactory
    {
        public INodeViewModel CreateRoot()
        {
            return new DocumentNodeViewModel(null, NodeType.KtcDocument);
        }

        public INodeViewModel Create(INodeViewModel parent, NodeType nodeType)
        {
            var result = new DocumentNodeViewModel(parent, nodeType);
            parent.Children.Add(result);
            return result;
        }
    }
}