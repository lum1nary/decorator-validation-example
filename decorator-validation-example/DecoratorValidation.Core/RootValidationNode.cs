namespace DecoratorValidation.Core
{
    public class RootValidationNode : ValidationNode
    {
        public override int Depth => 0;

        public override IValidationNode Parent => this;

        public RootValidationNode() : base(null)
        {
        }
    }
}