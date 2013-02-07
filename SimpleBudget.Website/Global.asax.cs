using Autofac;
using Funq;
using ServiceStack.Configuration;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.WebHost.Endpoints;
using SimpleBudget.Data;
using SimpleBudget.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SimpleBudget.Website
{
    public class Global : System.Web.HttpApplication
    {
        public class SimpleBudgetAppHost : AppHostBase
        {
            public SimpleBudgetAppHost() : base("SimpleBudgetService", typeof(SimpleBudgetService).Assembly) { }

            public override void Configure(Container container)
            {
                //register any dependencies your services use, e.g:
                ContainerBuilder builder = new ContainerBuilder();

                builder.RegisterModule(new AutofacDataModule());
                
                // register our base service
                builder.RegisterType<SimpleBudgetService>().As<ISimpleBudgetService>().InstancePerLifetimeScope();

                // register custom authorize provider
                builder.RegisterType<CustomCredentialsAuthProvider>().As<IAuthProvider>().InstancePerLifetimeScope();
                

                IContainerAdapter adapter = new AutofacIocAdapter(builder.Build());
                container.Adapter = adapter;

                Plugins.Add(
                    new AuthFeature(() => new AuthUserSession(), 
                        new IAuthProvider[] 
                        {
                            adapter.Resolve<IAuthProvider>(), //HTML Form post of UserName/Password credentials
                        }
                ));
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            new SimpleBudgetAppHost().Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }

    public class AutofacIocAdapter : IContainerAdapter
    {
        private readonly IContainer _container;

        public AutofacIocAdapter(IContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public T TryResolve<T>()
        {
            T result;

            if (_container.TryResolve<T>(out result))
            {
                return result;
            }

            return default(T);
        }
    }
}