using Autofac;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.PostgreSQL;
using SimpleBudget.Data;
using SimpleBudget.Data.OrmLite;
using SimpleBudget.DataMock.Repositories;
using SimpleBudget.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.Tests
{
    public class AutofacDataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            OrmLiteConfig.DialectProvider = PostgreSQLDialectProvider.Instance;
            ServiceStack.OrmLite.OrmLiteConfig.DialectProvider.NamingStrategy = new LowercaseNamingStrategy();

            var connectionFactory = new OrmLiteConnectionFactory("Server=127.0.0.1;Port=5432;Database=transactions;User Id=postgres;Password=canada;", false, PostgreSqlDialect.Provider);

            using (var db = connectionFactory.OpenDbConnection())
            {
                DbSetup.Setup(db);
            }

            builder.Register(c => connectionFactory).As<IDbConnectionFactory>();


            builder.RegisterType<UserRepository>().As<IUserRepository>().As<IRepository<User>>().InstancePerLifetimeScope();
            builder.RegisterType<BudgetRepository>().As<IBudgetRepository>().As<IRepository<Budget>>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().As<IRepository<Category>>().InstancePerLifetimeScope();
            builder.RegisterType<TransactionRepository>().As<ITransactionRepository>().As<IRepository<Transaction>>().InstancePerLifetimeScope();

            //builder.RegisterType<UserRepository>().As<IRepository<User>>().InstancePerLifetimeScope();
            //builder.RegisterType<BudgetRepository>().As<IRepository<Budget>>().InstancePerLifetimeScope();
            //builder.RegisterType<CategoryRepository>().As<IRepository<Category>>().InstancePerLifetimeScope();
            //builder.RegisterType<TransactionRepository>().As<IRepository<Transaction>>().InstancePerLifetimeScope();
            builder.RegisterType<BillRepository>().As<IRepository<Bill>>().InstancePerLifetimeScope();

            

            // make sure our mock provider is accessible through IVoiceProvider and MockProvider for when we need to fake validation for things.
            //builder.RegisterType<MockProvider>().As<IVoiceProvider>().As<MockProvider>().InstancePerLifetimeScope();
            //builder.RegisterType<VoiceCore>().As<IVoiceCore>().As<VoiceCore>().InstancePerLifetimeScope();
        }
    }
}
