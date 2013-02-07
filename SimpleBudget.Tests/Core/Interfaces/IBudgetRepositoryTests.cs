using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.OrmLite;
using SimpleBudget.Interfaces;
using SimpleBudget.Data.OrmLite;
using SimpleBudget.Data;
using Autofac;
using ServiceStack.OrmLite.PostgreSQL;

namespace SimpleBudget.Tests.Core.Interfaces
{
    [TestClass]
    public class IBudgetRepositoryTests : TestBase
    {

        IUserRepository userRepository;
        IBudgetRepository budgetRepository;
        ICategoryRepository categoryRepository;
        ITransactionRepository transactionRepository;
        //IRepositoryUnitOfWork context;

        User user;
        Budget budget;
        Category category;
        Transaction transaction;

        protected override void Initialize()
        {
            //userRepository = testSetup.Resolve<IUserRepository>();
            //budgetRepository = testSetup.Resolve<IBudgetRepository>();
            //categoryRepository = testSetup.Resolve<ICategoryRepository>();
            //transactionRepository = testSetup.Resolve<ITransactionRepository>();


            user = new User { Id = Guid.NewGuid(), FirstName = "Test", LastName = "User", Email = "testuser@test.com", DisplayName = "Sir. Test User" };
            budget = new Budget { Id = Guid.NewGuid(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(12), Frequency = Frequency.Monthly };
            category = new Category { Id = Guid.NewGuid(), Name = "Bills", Frequency = budget.Frequency };
            transaction = new Transaction { Id = Guid.NewGuid(), Description = "Test Transaction", Amount = 15.00m, Date = DateTime.Now, TransactionType = TransactionType.Outgoing };
        }

        [TestMethod]
        public void AddCategoryToBudget_GetCategoriesByBudgetId()
        //public void AddBudgetToUser(Guid budgetId, Guid userId)
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Budgets.Create(budget);
                context.Categories.Create(category);

                context.Budgets.AddCategoryToBudget(category.Id, budget.Id);

                var categories = context.Budgets.GetCategoriesByBudgetId(budget.Id);

                Assert.IsNotNull(categories);
                Assert.AreEqual(1, categories.Count);
            }
        }

        [TestMethod]
        public void RemoveCategoryFromBudget()
        //public void RemoveBudgetFromUser(Guid budgetId, Guid userId)
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Budgets.Create(budget);
                context.Categories.Create(category);

                context.Budgets.AddCategoryToBudget(category.Id, budget.Id);

                var categories = context.Budgets.GetCategoriesByBudgetId(budget.Id);

                Assert.IsNotNull(categories);
                Assert.AreEqual(1, categories.Count);

                context.Budgets.RemoveCategoryFromBudget(category.Id, budget.Id);

                categories = context.Budgets.GetCategoriesByBudgetId(budget.Id);

                Assert.IsNotNull(categories);
                Assert.AreEqual(0, categories.Count);

            }
        }

        [TestMethod]
        public void AddTransactionToBudget_GetTransactionsByBudgetId()
        //public void AddBudgetToUser(Guid budgetId, Guid userId)
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Budgets.Create(budget);
                context.Transactions.Create(transaction);

                context.Budgets.AddTransactionToBudget(transaction.Id, budget.Id);

                var transactions = context.Budgets.GetTransactionsByBudgetId(budget.Id);

                Assert.IsNotNull(transactions);
                Assert.AreEqual(1, transactions.Count);
            }
        }

        [TestMethod]
        public void RemoveTransactionFromBudget()
        //public void RemoveBudgetFromUser(Guid budgetId, Guid userId)
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Budgets.Create(budget);
                context.Transactions.Create(transaction);

                context.Budgets.AddTransactionToBudget(transaction.Id, budget.Id);

                var transactions = context.Budgets.GetTransactionsByBudgetId(budget.Id);

                Assert.IsNotNull(transactions);
                Assert.AreEqual(1, transactions.Count);

                context.Budgets.RemoveTransactionFromBudget(transaction.Id, budget.Id);

                transactions = context.Budgets.GetTransactionsByBudgetId(budget.Id);

                Assert.IsNotNull(transactions);
                Assert.AreEqual(0, transactions.Count);

            }
        }
    }
}
