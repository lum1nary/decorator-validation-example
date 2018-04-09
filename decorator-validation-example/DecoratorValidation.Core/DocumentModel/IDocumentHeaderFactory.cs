namespace DecoratorValidation.Core.DocumentModel
{
    public interface IDocumentHeaderFactory
    {
        INodeViewModel CreateHeader(INodeViewModel doc);
    }
}