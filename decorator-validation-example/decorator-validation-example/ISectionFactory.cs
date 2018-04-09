namespace DecoratorValidation.Core
{
    public interface ISectionFactory
    {
        INodeViewModel CreateSection(INodeViewModel parent, NodeType nodeType);
    }
}