using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace DecoratorValidation.Core
{
    public class NodeValidationDecorator : ViewModelBase, INodeViewModel, IValidationNode
    {
        private readonly IValidationService _validationService;

        public IValidationNode ValidationNode { get; }

        #region IValidationNode
        int IValidationNode.Depth => ValidationNode.Depth;

        IValidationNode IValidationNode.Parent => ValidationNode.Parent;

        IList<IValidationNode> IValidationNode.Children => ValidationNode.Children;

        INodeViewModel IValidationNode.Node => ValidationNode.Node;

        IValidationResult IValidationNode.ValidationState => ValidationNode.ValidationState;
        #endregion

        #region INodeViewModel

        public INodeViewModel Parent => ValidationNode.Node.Parent;
        public IList<INodeViewModel> Children => ValidationNode.Node.Children;

        public string Value
        {
            get => ValidationNode.Node.Value;
            set
            {
                ValidationNode.Node.Value = value;
                RaisePropertyChanged();
            }
        }

        public NodeType NodeType => ValidationNode.Node.NodeType;

        #endregion

        public NodeValidationDecorator(
            IValidationNode validationNode,
            IValidationService validationService)
        {
            ValidationNode = validationNode;
            _validationService = validationService;
        }
    }
}