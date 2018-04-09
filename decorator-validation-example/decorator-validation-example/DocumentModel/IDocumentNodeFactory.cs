namespace DecoratorValidation.Core.DocumentModel
{
    public interface IDocumentNodeFactory
    {
        INodeViewModel CreateRoot();

        INodeViewModel Create(INodeViewModel parent, NodeType nodeType);
    }
}