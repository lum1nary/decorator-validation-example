using Autofac;
using DecoratorValidation.Core;
using DecoratorValidation.Core.TreeConductors;

namespace DecoratorValidation.Registration.Modules
{
    public class ValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NodeTreeConductor> ().As<ITreeConductor<INodeViewModel>>();
            builder.RegisterType<ValidationProcessor>().As<IValidationProcessor>();
            builder.RegisterType<ValidationService>().As<IValidationService>();

        }
    }
}