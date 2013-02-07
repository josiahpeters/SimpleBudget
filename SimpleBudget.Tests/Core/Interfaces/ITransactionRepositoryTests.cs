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
        User user;
        Budget budget;

        protected override void Initialize()
        {
            user = new User { Id = Guid.NewGuid(), FirstName = "Test", LastName = "User", Email = "testuser@test.com", DisplayName = "Sir. Test User" };
            budget = new Budget { Id = Guid.NewGuid(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(12), Frequency = Frequency.Monthly };
        }
    }
}
