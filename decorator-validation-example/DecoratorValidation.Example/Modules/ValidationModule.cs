﻿using Autofac;
using DecoratorValidation.Core;

namespace DecoratorValidation.Example.Modules
{
    public class ValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ValidationService>().As<IValidationService>();
        }
    }
}