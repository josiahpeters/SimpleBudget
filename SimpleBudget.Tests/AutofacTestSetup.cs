using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.Tests
{
    public class AutofacTestSetup
    {
        ContainerBuilder builder;

        IContainer container;

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public T ResolveLifetime<T>()
        {
            return container.Resolve<T>();
        }

        public IContainer Container { get { return container; } }

        public AutofacTestSetup(Module module = null)
        {
            builder = new ContainerBuilder();

            builder.RegisterModule(new AutofacDataModule());
            // builder.RegisterModule(new AutofacMockModule());

            //if (module != null)
            //    builder.RegisterModule(module);
            //else
            //    builder.RegisterModule(new AutofacMockModule());

            container = builder.Build();
        }
    }
}
