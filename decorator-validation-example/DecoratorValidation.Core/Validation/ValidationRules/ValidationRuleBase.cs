﻿using DecoratorValidation.Core.TreeConductors;

namespace DecoratorValidation.Core.ValidationRules
{
    public abstract class ValidationRuleBase : IValidationRule
    {
        protected string Message;

        protected ValidationRuleBase(string message = "")
        {
            Message = message;
        }

        public abstract IValidationResult Validate(INodeViewModel node, ITreeConductor<INodeViewModel> conductor);
    }
}