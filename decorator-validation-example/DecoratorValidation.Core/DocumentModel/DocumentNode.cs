using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace DecoratorValidation.Core.DocumentModel
{
    public class DocumentNodeViewModel : ViewModelBase, INodeViewModel
    {
        public INodeViewModel Parent { get; }
        public IList<INodeViewModel> Children { get; } = new List<INodeViewModel>();

        public string Value { get; set; }
        public NodeType NodeType { get; }

        public DocumentNodeViewModel(INodeViewModel parent, NodeType nodeType)
        {
            Parent = parent;
            NodeType = nodeType;
        }
    }
}