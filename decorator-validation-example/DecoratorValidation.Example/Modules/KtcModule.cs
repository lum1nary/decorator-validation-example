using Autofac;
using DecoratorValidation.Core;
using DecoratorValidation.Core.DocumentModel;
using DecoratorValidation.Core.DocumentModel.KTC;

namespace DecoratorValidation.Example.Modules
{
    public class KtcModule : DocumentModule
    {
        protected override DocumentType Key => DocumentType.KTC;

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<KtcDocumentNodeFactory>()
                .Keyed<IDocumentNodeFactory>(Key)
                .SingleInstance();

            builder.Register(c => new KtcDocumentHeaderFactory(c.ResolveKeyed<IDocumentNodeFactory>(Key)))
                .Keyed<IDocumentHeaderFactory>(Key)
                .SingleInstance();

            builder.Register(c => new KtcDocumentBodyFactory(
                    c.ResolveKeyed<IDocumentNodeFactory>(Key),
                    c.ResolveKeyed<IAssemblyDrawingFactory>(Key),
                    c.ResolveKeyed<IDocumentRowFactory>(Key),
                    c.ResolveKeyed<ISectionFactory>(Key)))
                .Keyed<IDocumentBodyFactory>(Key)
                .SingleInstance();

            builder.Register(c => new KtcDocumentRowFactory(c.ResolveKeyed<IDocumentNodeFactory>(Key)))
                .Keyed<IAssemblyDrawingFactory>(Key)
                .Keyed<ISectionFactory>(Key)
                .Keyed<IDocumentRowFactory>(Key)
                .SingleInstance();

            builder.Register(c => new KtcDocumentFactory(
                        c.ResolveKeyed<IDocumentNodeFactory>(Key),
                        c.ResolveKeyed<IDocumentHeaderFactory>(Key),
                        c.ResolveKeyed<IDocumentBodyFactory>(Key)))
                .Keyed<IDocumentFactory>(Key)
                .SingleInstance();
        }
    }
}