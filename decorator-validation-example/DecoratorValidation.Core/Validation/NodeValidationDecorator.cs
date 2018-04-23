using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace DecoratorValidation.Core
{
    public class NodeValidationDecorator : ViewModelBase, IValidationNode
    {
        private readonly IValidationService _validationService;

        public INodeViewModel Node { get; }

        #region IValidationNode

        public int Depth => GetCurrentDepth();
        public IValidationResult ValidationState { get; set; }

        #endregion

        #region INodeViewModel

        public INodeViewModel Parent => Node.Parent;
        public IList<INodeViewModel> Children => Node.Children;

        public string Value
        {
            get => Node.Value;
            set
            {
                Node.Value = value;
                RaisePropertyChanged();
            }
        }

        public string NodeType => Node.NodeType;

        #endregion

        public NodeValidationDecorator(
            INodeViewModel node,
            IValidationService validationService)
        {
            Node = node;
            _validationService = validationService;
        }

        private int GetCurrentDepth()
        {
            int depth = 0;

            var parent = Node.Parent;
            while (parent != null)
            {
                depth++;
                parent = parent.Parent;
            }

            return depth;
        }
    }
}