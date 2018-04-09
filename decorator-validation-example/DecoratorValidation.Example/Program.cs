using System;
using Autofac;
using DecoratorValidation.Core;
using DecoratorValidation.Core.DocumentModel;
using DecoratorValidation.Example.Modules;

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

            _container = builder.Build();

            var ktcFactory = _container.ResolveKeyed<IDocumentFactory>(DocumentType.KTC);

            var doc = ktcFactory.CreateDocument();

            DisplayStructure(doc);
            Console.ReadKey();
        }

        private static void DisplayStructure(INodeViewModel root, int depth = 0)
        {
            Console.WriteLine($"{new string(' ', depth)} {root.GetType()}");
            foreach (var child in root.Children)
            {
                DisplayStructure(child, depth + 1);
            }
        }

    }
}
