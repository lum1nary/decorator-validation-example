using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace DecoratorValidation.Core.DocumentModel
{
    public class DocumentNodeViewModel : ViewModelBase, INodeViewModel
    {
        public INodeViewModel Parent { get; }
        public IList<INodeViewModel> Children { get; } = new List<INodeViewModel>();

        public string Value { get; set; }
        public int IntValue => int.Parse(Value);
        public double DoubleValue => double.Parse(Value);
        public DateTime DateValue => DateTime.Parse(Value);
        public string NodeType { get; }

        public DocumentNodeViewModel(INodeViewModel parent, string nodeType)
        {
            Parent = parent;
            NodeType = nodeType;
        }
    }
}