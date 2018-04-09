namespace DecoratorValidation.Core.DocumentModel
{
    public interface IDocumentRowFactory
    {
        INodeViewModel CreateRow(INodeViewModel parent);
    }
}