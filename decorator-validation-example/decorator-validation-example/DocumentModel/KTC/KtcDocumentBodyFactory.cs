namespace DecoratorValidation.Core.DocumentModel.KTC
{
    public class KtcDocumentBodyFactory : IDocumentBodyFactory
    {
        private readonly IDocumentNodeFactory _nodeFactory;
        private readonly IAssemblyDrawingFactory _assemblyDrawingFactory;
        private readonly IDocumentRowFactory _rowFactory;
        private readonly ISectionFactory _sectionFactory;

        public KtcDocumentBodyFactory(
            IDocumentNodeFactory nodeFactory,
            IAssemblyDrawingFactory assemblyDrawingFactory,
            IDocumentRowFactory rowFactory,
            ISectionFactory sectionFactory)
        {
            _nodeFactory = nodeFactory;
            _assemblyDrawingFactory = assemblyDrawingFactory;
            _rowFactory = rowFactory;
            _sectionFactory = sectionFactory;
        }

        public INodeViewModel CreateBody(INodeViewModel doc)
        {
            var body = _nodeFactory.Create(doc, NodeType.DocumentBody);
            var drawing = _assemblyDrawingFactory.CreateAssemblyDrawing(body);
            var section = _sectionFactory.CreateSection(drawing, NodeType.AssemblyUnitSection);
            _rowFactory.CreateRow(section);

            return body;
        }
    }
}