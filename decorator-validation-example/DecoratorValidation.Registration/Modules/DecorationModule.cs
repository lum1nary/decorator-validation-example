using System.Net.Http.Headers;
using Autofac;
using DecoratorValidation.Core;
using DecoratorValidation.Core.DocumentModel;

namespace DecoratorValidation.Registration.Modules
{
    public class DecorationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DocumentNodeFactory>()
                .Keyed<IDocumentNodeFactory>("basic_node")
                .SingleInstance();

            builder.RegisterDecorator<IDocumentNodeFactory>((c, factory) =>
                    new NodeFactoryValidationDecorator(factory, c.Resolve<IValidationService>()), "basic_node", "default_node")
                .SingleInstance();

            builder.RegisterDecorator<IDocumentNodeFactory>((c, factory) =>
                    //new NodeFactoryValidationDecorator(factory, c.Resolve<IValidationService>()), "basic_node", "document_root")
                        factory, "basic_node", "document_root")
                .SingleInstance();

            builder.RegisterDecorator<IDocumentNodeFactory>((c, factory) =>
                    new NodeFactoryIntDecorator(factory), "default_node", "a")
                .SingleInstance();

            builder.RegisterDecorator<IDocumentNodeFactory>((c, factory) =>
                    new NodeFactoryIntDecorator(factory), "default_node", "b")
                .SingleInstance();

            builder.RegisterDecorator<IDocumentNodeFactory>((c, factory) =>
                    new NodeFactoryIntDecorator(factory), "default_node", "c")
                .SingleInstance();

            builder.Register(c => new DecoratedNodeFactory(c.Resolve<IComponentContext>()))
                .As<IDocumentNodeFactory>()
                .SingleInstance();
        }
    }
}