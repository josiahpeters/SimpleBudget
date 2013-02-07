using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.OrmLite;
using SimpleBudget.Interfaces;
using SimpleBudget.Data.OrmLite;

namespace SimpleBudget.Tests.Core.Interfaces
{
    [TestClass]
    public class IBudgetRepositoryTests : TestBase
    {

        IUserRepository userRepository;
        IBudgetRepository budgetRepository;
        ICategoryRepository categoryRepository;
        ITransactionRepository transactionRepository;

        User user;
        Budget budget;
        Category category;
        Transaction transaction;

        protected override void Initialize()
        {
            userRepository = testSetup.Resolve<IUserRepository>();
            budgetRepository = testSetup.Resolve<IBudgetRepository>();
            categoryRepository = testSetup.Resolve<ICategoryRepository>();
            transactionRepository = testSetup.Resolve<ITransactionRepository>();

            user = new User { Id = Guid.NewGuid(), FirstName = "Test", LastName = "User", Email = "testuser@test.com", DisplayName = "Sir. Test User" };
            budget = new Budget { Id = Guid.NewGuid(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(12), Frequency = Frequency.Monthly };
            category = new Category { Id = Guid.NewGuid(), Name = "Bills", Frequency = budget.Frequency };
            transaction = new Transaction { Id = Guid.NewGuid(), Description = "Test Transaction", Amount = 15.00m, Date = DateTime.Now, TransactionType = TransactionType.Outgoing };
        }

        [TestMethod]
        public void AddCategoryToBudget_GetCategoriesByBudgetId()
        //public void AddBudgetToUser(Guid budgetId, Guid userId)
        {
            budgetRepository.Create(budget);
            categoryRepository.Create(category);

            budgetRepository.AddCategoryToBudget(category.Id, budget.Id);

            var categories = budgetRepository.GetCategoriesByBudgetId(budget.Id);

            Assert.IsNotNull(categories);
            Assert.AreEqual(1, categories.Count);
        }

        [TestMethod]
        public void RemoveCategoryFromBudget()
        //public void RemoveBudgetFromUser(Guid budgetId, Guid userId)
        {
            budgetRepository.Create(budget);
            categoryRepository.Create(category);

            budgetRepository.AddCategoryToBudget(category.Id, budget.Id);

            var categories = budgetRepository.GetCategoriesByBudgetId(budget.Id);

            Assert.IsNotNull(categories);
            Assert.AreEqual(1, categories.Count);

            budgetRepository.RemoveCategoryFromBudget(budget.Id, category.Id);

            categories = budgetRepository.GetCategoriesByBudgetId(budget.Id);

            Assert.IsNotNull(categories);
            Assert.AreEqual(0, categories.Count);

        }

        [TestMethod]
        public void AddTransactionToBudget_GetTransactionsByBudgetId()
        //public void AddBudgetToUser(Guid budgetId, Guid userId)
        {
            budgetRepository.Create(budget);
            transactionRepository.Create(transaction);

            budgetRepository.AddTransactionToBudget(transaction.Id, budget.Id);

            var transactions = budgetRepository.GetTransactionsByBudgetId(budget.Id);

            Assert.IsNotNull(transactions);
            Assert.AreEqual(1, transactions.Count);
        }

        [TestMethod]
        public void RemoveTransactionFromBudget()
        //public void RemoveBudgetFromUser(Guid budgetId, Guid userId)
        {
            budgetRepository.Create(budget);
            transactionRepository.Create(transaction);

            budgetRepository.AddTransactionToBudget(transaction.Id, budget.Id);

            var transactions = budgetRepository.GetTransactionsByBudgetId(budget.Id);

            Assert.IsNotNull(transactions);
            Assert.AreEqual(1, transactions.Count);

            budgetRepository.RemoveTransactionFromBudget(transaction.Id, budget.Id);

            transactions = budgetRepository.GetTransactionsByBudgetId(budget.Id);

            Assert.IsNotNull(transactions);
            Assert.AreEqual(0, transactions.Count);

        }
    }
}
