using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.OrmLite;
using SimpleBudget.Interfaces;
using SimpleBudget.Data.OrmLite;

namespace SimpleBudget.Tests.Core.Interfaces
{
    [TestClass]
    public class ICategoryRepositoryTests : TestBase
    {
        User user;
        Budget budget;
        Category category;
        Transaction transaction;

        protected override void Initialize()
        {

            user = new User { Id = Guid.NewGuid(), FirstName = "Test", LastName = "User", Email = "testuser@test.com", DisplayName = "Sir. Test User" };
            budget = new Budget { Id = Guid.NewGuid(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(12), Frequency = Frequency.Monthly };
            category = new Category { Id = Guid.NewGuid(), Name = "Bills", Frequency = budget.Frequency };
            transaction = new Transaction { Id = Guid.NewGuid(), Description = "Test Transaction", Amount = 15.00m, Date = DateTime.Now, TransactionType = TransactionType.Outgoing };
        }

        [TestMethod]
        public void AddTransactionToCategory_GetTransactionsByCategoryId()
        //public void AddBudgetToUser(Guid budgetId, Guid userId)
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Categories.Create(category);
                context.Transactions.Create(transaction);

                context.Categories.AddTransactionToCategory(transaction.Id, category.Id);

                var transactions = context.Categories.GetTransactionsByCategoryId(category.Id);

                Assert.IsNotNull(transactions);
                Assert.AreEqual(1, transactions.Count);
            }
        }

        [TestMethod]
        public void RemoveTransactionFromCategory()
        //public void RemoveBudgetFromUser(Guid budgetId, Guid userId)
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Categories.Create(category);
                context.Transactions.Create(transaction);

                context.Categories.AddTransactionToCategory(transaction.Id, category.Id);

                var transactions = context.Categories.GetTransactionsByCategoryId(category.Id);

                Assert.IsNotNull(transactions);
                Assert.AreEqual(1, transactions.Count);

                context.Categories.RemoveTransactionFromCategory(transaction.Id, category.Id);

                transactions = context.Categories.GetTransactionsByCategoryId(category.Id);

                Assert.IsNotNull(transactions);
                Assert.AreEqual(0, transactions.Count);
            }

        }
    }
}
