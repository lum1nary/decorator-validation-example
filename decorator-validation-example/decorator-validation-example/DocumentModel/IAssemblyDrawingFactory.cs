namespace DecoratorValidation.Core.DocumentModel
{
    public interface IAssemblyDrawingFactory
    {
        INodeViewModel CreateAssemblyDrawing(INodeViewModel parent);
    }
}