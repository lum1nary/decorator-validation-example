using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace DecoratorValidation.Core.DocumentModel
{
    public class NodeIntDecorator : ViewModelBase,  IDecoratedNode
    {
        public INodeViewModel Node { get; }

        public NodeIntDecorator(INodeViewModel node)
        {
            Node = node;
        }
        
        public INodeViewModel Parent => Node.Parent;

        public IList<INodeViewModel> Children => Node.Children;

        public string Value
        {
            get => Node.Value;
            set => Node.Value = value;
        }

        public string NodeType => Node.NodeType;

        public int IntValue => int.TryParse(Value, out int i) ? i : -1;
    }
}
