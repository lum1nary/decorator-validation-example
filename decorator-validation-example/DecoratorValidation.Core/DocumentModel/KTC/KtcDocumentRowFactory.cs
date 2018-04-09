namespace DecoratorValidation.Core.DocumentModel.KTC
{
    public class KtcDocumentRowFactory : IAssemblyDrawingFactory,
        ISectionFactory,
        IDocumentRowFactory
    {
        private readonly IDocumentNodeFactory _nodeFactory;

        public KtcDocumentRowFactory(IDocumentNodeFactory nodeFactory)
        {
            _nodeFactory = nodeFactory;
        }

        public INodeViewModel CreateRow(INodeViewModel parent)
        {
            return CreateRowInternal(parent, NodeType.DocumentRow);
        }

        public INodeViewModel CreateAssemblyDrawing(INodeViewModel parent)
        {
            var row = CreateRowInternal(parent, NodeType.AssemblyDrawing);

            return row;
        }

        private INodeViewModel CreateRowInternal(INodeViewModel parent, NodeType type)
        {
            var row = _nodeFactory.Create(parent, type);

            _nodeFactory.Create(row, NodeType.Kc);
            _nodeFactory.Create(row, NodeType.Description);
            _nodeFactory.Create(row, NodeType.Pkp);
            _nodeFactory.Create(row, NodeType.Quantity);
            _nodeFactory.Create(row, NodeType.Mass);
            _nodeFactory.Create(row, NodeType.Material);
            _nodeFactory.Create(row, NodeType.SeriesFrom);
            _nodeFactory.Create(row, NodeType.SeriesTo);
            _nodeFactory.Create(row, NodeType.QuantityPerUnit);
            _nodeFactory.Create(row, NodeType.Customer);
            _nodeFactory.Create(row, NodeType.To);
            _nodeFactory.Create(row, NodeType.Pokr);
            _nodeFactory.Create(row, NodeType.Spsh);
            _nodeFactory.Create(row, NodeType.Tk);

            return row;
        }

        public INodeViewModel CreateSection(INodeViewModel parent, NodeType nodeType)
        {
            var section = _nodeFactory.Create(parent, nodeType);

            CreateRowInternal(section, NodeType.DocumentRow);

            return section;
        }
    }
}