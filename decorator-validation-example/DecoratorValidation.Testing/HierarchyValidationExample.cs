﻿using System.Linq;
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
                    conductor.FindAll(node, i => i.ValidationState.IsValid &&
                                                 i.Node.NodeType == "b")
                        .Select(i => i.Node.IntValue)
                        .All(i => node.Node.IntValue > i)));
            _validationService.RegisterRules("b",
                new NotEmptyRule(),
                new DynamicValidationRule((node, conductor) => 
                    conductor.FindAll(node, i => i.Node.NodeType == "a" && 
                                                 i.ValidationState.IsValid)
                    .Select(i => i.Node.IntValue)
                    .All(i => node.Node.IntValue < i)),
                new DynamicValidationRule((node, conductor) =>
                    conductor.FindAll(node, i => i.ValidationState.IsValid &&
                                                 i.Node.NodeType == "c")
                        .Select(i => i.Node.IntValue)
                        .All(i => node.Node.IntValue > i))
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



        }
    }
}