using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorValidation.Core.DocumentModel
{
    public static class NodeExtentions
    {
        public static T As<T>(this INodeViewModel node) where T : class, INodeViewModel
        {
            var findNode = node as T;
            if (findNode == null)
            {
                var decoratedNode = node as IDecoratedNode;

                if (decoratedNode == null)
                {
                    return null;
                }

                return decoratedNode.Node.As<T>();
            }

            return findNode;
        }
    }
}
