using System;
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

        int IntValue { get; }

        double DoubleValue { get; }

        DateTime DateValue { get; }

        string NodeType { get; }
    }

}