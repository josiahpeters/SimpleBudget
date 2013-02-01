using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.Tests
{
    public class AutofacMockModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // make sure our mock provider is accessible through IVoiceProvider and MockProvider for when we need to fake validation for things.
            //builder.RegisterType<MockProvider>().As<IVoiceProvider>().As<MockProvider>().InstancePerLifetimeScope();
            //builder.RegisterType<VoiceCore>().As<IVoiceCore>().As<VoiceCore>().InstancePerLifetimeScope();
        }
    }
}
