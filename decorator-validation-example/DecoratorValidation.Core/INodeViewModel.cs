using System.Collections.Generic;
using System.ComponentModel;

namespace DecoratorValidation.Core
{
    //INotifyPropertyChanged is not nessesary
    public interface INodeViewModel : INotifyPropertyChanged
    {
        INodeViewModel Parent { get; }

        IList<INodeViewModel> Children { get; }

        string Value { get; set; }

        NodeType NodeType { get; }
    }

}