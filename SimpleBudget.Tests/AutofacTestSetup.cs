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

        public AutofacTestSetup(Module module = null)
        {
            builder = new ContainerBuilder();

            if (module != null)
                builder.RegisterModule(module);

            builder.RegisterModule(new AutofacMockModule());

            container = builder.Build();
        }
    }
}
