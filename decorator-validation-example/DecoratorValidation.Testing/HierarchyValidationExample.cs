using System.Linq;
using Autofac;
using DecoratorValidation.Core;
using DecoratorValidation.Core.DocumentModel;
using DecoratorValidation.Core.ValidationRules;
using Xunit;

namespace DecoratorValidation.Testing
{
    public class HierarchyValidationExample : IClassFixture<IocFixture>
    {
        private readonly IContainer _container;
        private readonly IDocumentNodeFactory _nodeFactory;
        private readonly IValidationService _validationService;

        private INodeViewModel _testRoot;

        public HierarchyValidationExample(IocFixture fixture)
        {
            _container = fixture.Container;
            _nodeFactory = _container.Resolve<IDocumentNodeFactory>();
            _validationService = _container.Resolve<IValidationService>();
            InitializeTestNodeStructure();
        }

        private void InitializeTestNodeStructure()
        {
            _validationService.RegisterRules("a",
                new NotEmptyRule(),
                new DynamicValidationRule((node, conductor) =>
                    conductor.FindAll(node, i => i.NodeType == "b")
                        .Select(i => int.TryParse(i.Value, out int j) ? j : 0)
                        .All(i => (int.TryParse(node.Value, out int j) ? j : 0)  > i)));
            _validationService.RegisterRules("b",
                new NotEmptyRule(),
                new DynamicValidationRule((node, conductor) =>
                    conductor.FindAll(node, i => i.NodeType == "a")
                        .Select(i => int.TryParse(i.Value, out int j) ? j : 0)
                        .All(i => (int.TryParse(node.Value, out int j) ? j : 0) < i)),
                new DynamicValidationRule((node, conductor) =>
                    conductor.FindAll(node, i => i.NodeType == "c")
                        .Select(i => int.TryParse(i.Value, out int j) ? j : 0)
                        .All(i => (int.TryParse(node.Value, out int j) ? j : 0)  > i))
                );

            _validationService.RegisterRules(NodeType.Date, 
                new NotEmptyRule()
                //new ValidDateRule() 
                );
        }

        public void SimpleHierarchyValidationTest()
        {
            var root = _nodeFactory.CreateRoot();
            var header = _nodeFactory.Create(root, "header");
            var aField = _nodeFactory.Create(header, "a");
            var bField = _nodeFactory.Create(header, "b");
            var cField = _nodeFactory.Create(header, "c");

            _validationService.Validate(aField);
            _validationService.Validate(bField);
            _validationService.Validate(cField);

            //or Alternatively validate upper node with
            //modification of validation service to pass boolean variable
            // in validate that order service to validate recursive all part of tree
            _validationService.Validate(header);
        }
    }
}