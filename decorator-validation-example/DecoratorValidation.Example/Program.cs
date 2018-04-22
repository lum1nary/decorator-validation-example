using System;
using System.Linq;
using Autofac;
using DecoratorValidation.Core;
using DecoratorValidation.Core.DocumentModel;
using DecoratorValidation.Core.ValidationRules;
using DecoratorValidation.Registration;
using DecoratorValidation.Registration.Modules;

namespace DecoratorValidation.Example
{
    class Program
    {
        private static IContainer _container;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule(new KtcModule());
            builder.RegisterModule(new ValidationModule());
            builder.RegisterModule(new DecorationModule());

            _container = builder.Build();

            

            var ktcFactory = _container.ResolveKeyed<IDocumentFactory>(DocumentType.KTC);
            var doc = ktcFactory.CreateDocument();
            DisplayStructure(doc); 
            Console.WriteLine("\n\n\n");

            var nodeFactory = _container.Resolve<IDocumentNodeFactory>();
            var root = nodeFactory.CreateRoot();
            var header = nodeFactory.Create(root, "header");
            var aField = nodeFactory.Create(header, "a");
            aField.Value = "7";

            var bField = nodeFactory.Create(header, "b");
            bField.Value = "5";

            var cField = nodeFactory.Create(header, "c");
            cField.Value = "3";

            var validationService = _container.Resolve<IValidationService>();
            RegisterRules(validationService);

            validationService.Validate(aField);
            validationService.Validate(bField);
            validationService.Validate(cField);

            //or Alternatively validate upper node with
            //modification of validation service to pass boolean variable
            // in validate that order service to validate recursive all part of tree
            validationService.Validate(header);

            DisplayStructure(root);

            Console.ReadKey(); 
        }

        private static void DisplayStructure(INodeViewModel root, int depth = 0)
        {
            Console.Write($"{new string(' ', depth)} {root.GetType().Name} {root.NodeType} {root.Value} ");

            var vNode = root.As<NodeValidationDecorator>();
            if (vNode != null && vNode.ValidationState != null)
            {
                var lastColor = Console.ForegroundColor;

                Console.ForegroundColor = vNode.ValidationState.IsValid
                    ? ConsoleColor.Green
                    : ConsoleColor.Red;

                Console.Write($"{vNode.ValidationState.IsValid} \"{vNode.ValidationState.Message}\"");

                Console.ForegroundColor = lastColor;
            }

            Console.WriteLine();

            foreach (var child in root.Children)
            {
                DisplayStructure(child, depth + 1);
            }
        }

        private static void RegisterRules(IValidationService validationService)
        {
            validationService.RegisterRules("a",
                new NotEmptyRule(),
                new DynamicValidationRule((node, conductor) =>
                    conductor.FindAll(node, i => i.NodeType == "b")
                        .Select(i => i.As<NodeIntDecorator>().IntValue)
                        .All(i => node.As<NodeIntDecorator>().IntValue > i)));
            validationService.RegisterRules("b",
                new NotEmptyRule(),
                new DynamicValidationRule((node, conductor) =>
                    conductor.FindAll(node, i => i.NodeType == "a")
                        .Select(i => i.As<NodeIntDecorator>().IntValue)
                        .All(i => node.As<NodeIntDecorator>().IntValue < i)),
                new DynamicValidationRule((node, conductor) =>
                    conductor.FindAll(node, i => i.NodeType == "c")
                        .Select(i => i.As<NodeIntDecorator>().IntValue)
                        .All(i => node.As<NodeIntDecorator>().IntValue > i))
            );

            validationService.RegisterRules(NodeType.Date,
                new NotEmptyRule()
                //new ValidDateRule() 
            );
        }
    }
}