using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.OrmLite;
using SimpleBudget.Interfaces;
using SimpleBudget.Data.OrmLite;

namespace SimpleBudget.Tests.Core.Interfaces
{
    [TestClass]
    public class ITransactionRepositoryTests : TestBase
    {

        IUserRepository userRepository;
        IBudgetRepository budgetRepository;

        User user;
        Budget budget;

        protected override void Initialize()
        {
            userRepository = testSetup.Resolve<IUserRepository>();
            budgetRepository = testSetup.Resolve<IBudgetRepository>();

            user = new User { Id = Guid.NewGuid(), FirstName = "Test", LastName = "User", Email = "testuser@test.com", DisplayName = "Sir. Test User" };
            budget = new Budget { Id = Guid.NewGuid(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(12), Frequency = Frequency.Monthly };
        }

        [TestMethod]
        public void AddBudgetToUser_GetBudgetsByUserId()
        //public void AddBudgetToUser(Guid budgetId, Guid userId)
        {
            budgetRepository.Create(budget);
            userRepository.Create(user);

            userRepository.AddBudgetToUser(budget.Id, user.Id);

            var budgets = userRepository.GetBudgetsByUserId(user.Id);

            Assert.IsNotNull(budgets);
            Assert.AreEqual(1, budgets.Count);
        }

        [TestMethod]
        public void RemoveBudgetFromUser()
        //public void RemoveBudgetFromUser(Guid budgetId, Guid userId)
        {
            budgetRepository.Create(budget);
            userRepository.Create(user);

            userRepository.AddBudgetToUser(budget.Id, user.Id);

            var budgets = userRepository.GetBudgetsByUserId(user.Id);

            Assert.IsNotNull(budgets);
            Assert.AreEqual(1, budgets.Count);

            userRepository.RemoveBudgetFromUser(budget.Id, user.Id);

            budgets = userRepository.GetBudgetsByUserId(user.Id);

            Assert.IsNotNull(budgets);
            Assert.AreEqual(0, budgets.Count);

        }
    }
}
