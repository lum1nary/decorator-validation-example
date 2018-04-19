using System;
using Autofac;
using DecoratorValidation.Core;
using DecoratorValidation.Core.DocumentModel;
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

            var builder = new ContainerBuilder();
            builder.RegisterModule(new KtcModule());
            builder.RegisterModule(new ValidationModule());

            _container = builder.Build();

            var ktcFactory = _container.ResolveKeyed<IDocumentFactory>(DocumentType.KTC);

            var doc = ktcFactory.CreateDocument();

            DisplayStructure(doc);
            Console.WriteLine("\n\n\n");
            DisplayValidStructureIfExists(doc);
            Console.ReadKey();
        }

        private static void DisplayStructure(INodeViewModel root, int depth = 0)
        {
            Console.WriteLine($"{new string(' ', depth)} {root.GetType().Name} {root.NodeType}");
            foreach (var child in root.Children)
            {
                DisplayStructure(child, depth + 1);
            }
        }

        private static void DisplayValidStructureIfExists(INodeViewModel root, int depth = 0)
        {
            var originRoot = (IValidationNode) root;
            Console.WriteLine($"{new string(' ', depth)} {originRoot.GetType().Name} {originRoot.Node.NodeType}");
            foreach (var child in originRoot.Children)
            {
                DisplayValidStructure(child, depth + 1);
            }
        }

        private static void DisplayValidStructure(IValidationNode root, int depth)
        {
            Console.WriteLine($"{new string(' ', depth)} {root.GetType().Name} {root.Node.NodeType}");
            foreach (var child in root.Children)
            {
                DisplayValidStructure(child, depth + 1);
            }
        }
    }
}