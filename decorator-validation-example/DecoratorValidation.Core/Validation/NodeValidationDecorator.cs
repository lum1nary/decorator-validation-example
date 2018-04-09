using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace DecoratorValidation.Core
{
    public class NodeValidationDecorator : ViewModelBase, INodeViewModel
    {
        private readonly IValidationService _validationService;

        private readonly IValidationNode _validationNode;

        #region INodeViewModel

        public INodeViewModel Parent => _validationNode.Node.Parent;
        public IList<INodeViewModel> Children => _validationNode.Node.Children;

        public string Value
        {
            get => _validationNode.Node.Value;
            set
            {
                _validationNode.Node.Value = value;
                RaisePropertyChanged();
            }
        }

        public NodeType NodeType => _validationNode.Node.NodeType;

        #endregion

        public NodeValidationDecorator(
            IValidationNode validationNode,
            IValidationService validationService)
        {
            _validationNode = validationNode;
            _validationService = validationService;
        }
    }
}