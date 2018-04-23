using System;
using System.Collections.Generic;
using DecoratorValidation.Core.TreeConductors;

namespace DecoratorValidation.Core
{
    public class NodeTreeConductor : ITreeConductor<INodeViewModel>
    {
        public INodeViewModel FindFirstUpper(INodeViewModel from, Predicate<INodeViewModel> predicate)
        {
            var upper = from.Parent;
            while (upper != null)
            {
                if (predicate(upper))
                    return upper;
                upper = upper.Parent;
            }

            return null;
        }

        public IEnumerable<INodeViewModel> FinUpperAll(INodeViewModel from, Predicate<INodeViewModel> predicate)
        {
            var result = new List<INodeViewModel>();

            var upper = from.Parent;
            while (upper != null)
            {
                if (predicate(upper))
                {
                    result.Add(upper);
                }

                upper = upper.Parent;
            }

            return result;
        }

        public INodeViewModel FindFirstLower(INodeViewModel from, Predicate<INodeViewModel> predicate)
        {
            if (from.Children == null || from.Children.Count == 0)
                return null;

            foreach (var child in from.Children)
            {
                if (predicate(child))
                {
                    return child;
                }

                return FindFirstLower(child, predicate);
            }

            return null;
        }

        public IEnumerable<INodeViewModel> FindLowerAll(INodeViewModel from, Predicate<INodeViewModel> predicate)
        {
            throw new NotImplementedException();
        }

        public INodeViewModel Find(INodeViewModel from, Predicate<INodeViewModel> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<INodeViewModel> FindAll(INodeViewModel from, Predicate<INodeViewModel> predicate)
        {
            var result = new List<INodeViewModel>();

            var root = from;
            while (root.Parent != null)
            {
                root = root.Parent;
            }

            FindInTreeInternal(root, predicate, result);

            return result;
        }

        private void FindInTreeInternal(INodeViewModel node, Predicate<INodeViewModel> predicate, List<INodeViewModel> list)
        {
            if(predicate(node))
                list.Add(node);

            foreach (INodeViewModel child in node.Children)
            {
                FindInTreeInternal(child, predicate, list);
            }
        }
    }
}