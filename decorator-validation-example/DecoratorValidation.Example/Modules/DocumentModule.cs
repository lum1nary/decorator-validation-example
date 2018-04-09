using Autofac;

namespace DecoratorValidation.Example.Modules
{
    public abstract class DocumentModule : Module
    {
        protected abstract DocumentType Key { get; }
        protected string DecoratorKey => "valid-" + Key;
    }
}