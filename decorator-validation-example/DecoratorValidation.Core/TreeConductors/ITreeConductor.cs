using System;
using System.Collections.Generic;

namespace DecoratorValidation.Core.TreeConductors
{
    public interface ITreeConductor<T> where T : class
    {
        T FindFirstUpper(T from, Predicate<T> predicate);
        IEnumerable<T> FinUpperAll(T from, Predicate<T> predicate);
        T FindFirstLower(T from, Predicate<T> predicate);
        IEnumerable<T> FindLowerAll(T from, Predicate<T> predicate);

        T Find(T from, Predicate<T> predicate);
        IEnumerable<T> FindAll(T from, Predicate<T> predicate);
    }
}