using Autofac;
using DecoratorValidation.Core;
using DecoratorValidation.Registration.Modules;

namespace DecoratorValidation.Testing
{
    public class IocFixture
    {
        public IContainer Container { get; }

        public IocFixture()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<KtcModule>();
            builder.RegisterType<ValidationService>()
                .As<IValidationService>()
                .SingleInstance();

            Container = builder.Build();
        }
    }
}