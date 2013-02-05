using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.OrmLite;
using SimpleBudget.Interfaces;
using SimpleBudget.Data.OrmLite;

namespace SimpleBudget.Tests.Core.Interfaces
{
    [TestClass]
    public class IUserRepositoryTests
    {
        AutofacTestSetup testSetup;

        IRepository<User> userRepository;

        User user;
        Budget budget;

        [TestInitialize]
        public void Init()
        {
            testSetup = new AutofacTestSetup();

            userRepository = testSetup.Resolve<IUserRepository>();

            initializeTestData();
        }

        private void initializeTestData()
        {
            user = new User { Id = Guid.NewGuid(), FirstName = "Test", LastName = "User", Email = "testuser@test.com", DisplayName = "Sir. Test User"  };
            budget = new Budget { Id = Guid.NewGuid(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(12), Frequency = Frequency.Monthly };
        }

        [TestMethod]
        public void CreateAndGetUser()
        {
            userRepository.Create(user);
            var newUser = userRepository.Get(user.Id);

            Assert.AreEqual(user.Id, newUser.Id);
        }
    }
}
