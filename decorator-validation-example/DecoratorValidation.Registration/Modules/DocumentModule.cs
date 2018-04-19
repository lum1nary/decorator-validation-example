using Autofac;

namespace DecoratorValidation.Registration.Modules
{
    public abstract class DocumentModule : Module
    {
        protected abstract DocumentType Key { get; }
        protected string DecoratorKey => "valid-" + Key;
    }
}