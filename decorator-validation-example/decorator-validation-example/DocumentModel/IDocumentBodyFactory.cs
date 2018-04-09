namespace DecoratorValidation.Core.DocumentModel
{
    public interface IDocumentBodyFactory
    {
        INodeViewModel CreateBody(INodeViewModel doc);
    }
}