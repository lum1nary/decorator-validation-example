using Autofac;
using DecoratorValidation.Core;
using DecoratorValidation.Core.DocumentModel;
using DecoratorValidation.Core.DocumentModel.KTC;

namespace DecoratorValidation.Registration.Modules
{
    public class KtcModule : DocumentModule
    {
        protected override DocumentType Key => DocumentType.KTC;

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new KtcDocumentHeaderFactory(c.Resolve<IDocumentNodeFactory>()))
                .Keyed<IDocumentHeaderFactory>(Key)
                .SingleInstance();

            builder.Register(c => new KtcDocumentBodyFactory(
                    c.Resolve<IDocumentNodeFactory>(),
                    c.ResolveKeyed<IAssemblyDrawingFactory>(Key),
                    c.ResolveKeyed<IDocumentRowFactory>(Key),
                    c.ResolveKeyed<ISectionFactory>(Key)))
                .Keyed<IDocumentBodyFactory>(Key)
                .SingleInstance();

            builder.RegisterType<KtcDocumentRowFactory>()
                .Keyed<IAssemblyDrawingFactory>(Key)
                .Keyed<ISectionFactory>(Key)
                .Keyed<IDocumentRowFactory>(Key)
                .SingleInstance();

            builder.Register(c => new KtcDocumentFactory(
                        c.Resolve<IDocumentNodeFactory>(),
                        c.ResolveKeyed<IDocumentHeaderFactory>(Key),
                        c.ResolveKeyed<IDocumentBodyFactory>(Key)))
                .Keyed<IDocumentFactory>(Key)
                .SingleInstance();
        }
    }
}