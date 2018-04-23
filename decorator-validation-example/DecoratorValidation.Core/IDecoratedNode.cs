namespace DecoratorValidation.Core
{
    public interface IDecoratedNode : INodeViewModel
    {
        INodeViewModel Node { get; }
    }
}