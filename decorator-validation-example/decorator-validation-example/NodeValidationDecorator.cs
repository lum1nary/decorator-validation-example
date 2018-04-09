using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace DecoratorValidation.Core
{
    public class NodeValidationDecorator : ViewModelBase, INodeViewModel
    {
        private readonly INodeViewModel _node;

        private readonly IValidationService _validationService;

        private readonly IValidationNode _validationNode;

        #region INodeViewModel

        public INodeViewModel Parent => _node.Parent;
        public IList<INodeViewModel> Children => _node.Children;

        public string Value
        {
            get => _node.Value;
            set
            {
                _node.Value = value;
                RaisePropertyChanged();
            }
        }

        public NodeType NodeType => _node.NodeType;

        #endregion

        public NodeValidationDecorator(
            INodeViewModel decoratedNode,
            IValidationService validationService)
        {
            _node = decoratedNode;
            _validationService = validationService;
        }
    }
}