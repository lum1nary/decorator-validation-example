using System;
using System.Collections.Generic;

namespace DecoratorValidation.Core.TreeConductors
{
    public class NullTreeConductor<T> : ITreeConductor<T> where T : class
    {
        public T FindFirstUpper(T @from, Predicate<T> predicate)
        {
            return from;
        }

        public IEnumerable<T> FinUpperAll(T @from, Predicate<T> predicate)
        {
            return new[] {from};
        }

        public T FindFirstLower(T @from, Predicate<T> predicate)
        {
            return from;
        }

        public IEnumerable<T> FindLowerAll(T @from, Predicate<T> predicate)
        {
            return new[] {from};
        }

        public T Find(T @from, Predicate<T> predicate)
        {
            return from;
        }

        public IEnumerable<T> FindAll(T @from, Predicate<T> predicate)
        {
            return new [] {from};
        }
    }
}