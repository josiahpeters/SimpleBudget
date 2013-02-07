using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.OrmLite;
using SimpleBudget.Interfaces;
using SimpleBudget.Data.OrmLite;

namespace SimpleBudget.Tests.Core.Interfaces
{
    [TestClass]
    public class IUserRepositoryTests : TestBase
    {
        User user;
        Budget budget;

        protected override void Initialize()
        {
            user = new User { Id = Guid.NewGuid(), FirstName = "Test", LastName = "User", Email = "testuser@test.com", DisplayName = "Sir. Test User" };
            budget = new Budget { Id = Guid.NewGuid(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(12), Frequency = Frequency.Monthly };
        }

        [TestMethod]
        public void AuthenticateUser()
        //public bool AuthenticateUser(string username, string password)
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {

                string password = "canada";

                user.PasswordHash = Common.HashPassword(password);

                context.Users.Create(user);

                var isUserAuthenticated = context.Users.AuthenticateUser(user.Email, password);

                Assert.IsTrue(isUserAuthenticated);
            }
        }

        [TestMethod]
        public void AddBudgetToUser_GetBudgetsByUserId()
        //public void AddBudgetToUser(Guid budgetId, Guid userId)
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {

                context.Budgets.Create(budget);
                context.Users.Create(user);

                context.Users.AddBudgetToUser(budget.Id, user.Id);

                var budgets = context.Users.GetBudgetsByUserId(user.Id);

                Assert.IsNotNull(budgets);
                Assert.AreEqual(1, budgets.Count);
            }
        }

        [TestMethod]
        public void RemoveBudgetFromUser()
        //public void RemoveBudgetFromUser(Guid budgetId, Guid userId)
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {

                context.Budgets.Create(budget);
                context.Users.Create(user);

                context.Users.AddBudgetToUser(budget.Id, user.Id);

                var budgets = context.Users.GetBudgetsByUserId(user.Id);

                Assert.IsNotNull(budgets);
                Assert.AreEqual(1, budgets.Count);

                context.Users.RemoveBudgetFromUser(budget.Id, user.Id);

                budgets = context.Users.GetBudgetsByUserId(user.Id);

                Assert.IsNotNull(budgets);
                Assert.AreEqual(0, budgets.Count);

            }
        }
    }
}
