using Autofac;
using SimpleBudget.DataMock.Repositories;
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
            builder.RegisterType<MockRepository<User>>().As<IRepository<User>>().InstancePerLifetimeScope(); ;
            builder.RegisterType<MockRepository<Budget>>().As<IRepository<Budget>>().InstancePerLifetimeScope(); ;
            builder.RegisterType<MockRepository<Category>>().As<IRepository<Category>>().InstancePerLifetimeScope(); ;
            builder.RegisterType<MockRepository<Transaction>>().As<IRepository<Transaction>>().InstancePerLifetimeScope(); ;
            builder.RegisterType<MockRepository<Bill>>().As<IRepository<Bill>>().InstancePerLifetimeScope(); ;

            // make sure our mock provider is accessible through IVoiceProvider and MockProvider for when we need to fake validation for things.
            //builder.RegisterType<MockProvider>().As<IVoiceProvider>().As<MockProvider>().InstancePerLifetimeScope();
            //builder.RegisterType<VoiceCore>().As<IVoiceCore>().As<VoiceCore>().InstancePerLifetimeScope();
        }
    }
}
