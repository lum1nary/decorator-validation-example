using System;

namespace DecoratorValidation.Core
{
    [Flags]
    public enum ValidationStyle
    {
        None = 0,
        OnPropertyChanged = 1,
        OnQuery = 2,
        Mixed = OnPropertyChanged | OnQuery
    }
}