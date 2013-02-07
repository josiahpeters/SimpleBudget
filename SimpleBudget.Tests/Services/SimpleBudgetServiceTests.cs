using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.ServiceClient.Web;
using SimpleBudget.Commands;
using SimpleBudget.Services;
using SimpleBudget.Queries;

namespace SimpleBudget.Tests.Services
{
    [TestClass]
    public class SimpleBudgetServiceTests : TestBase
    {
        [TestMethod]
        public void UserCreateCommand()
        {
            //var client = new JsonServiceClient();

            var command = new UserCreateCommand
            {
                FirstName = "Test",
                LastName = "User",
                Email = "testuser@test.com",
                DisplayName = "Sir. Test User",
                Password = "canada"
            };

            var service = testSetup.Resolve<ISimpleBudgetService>();

            var response = service.Post(command) as CreateResponse;

            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                var user = context.Users.Get(response.Id);

                Assert.IsNotNull(user);
                Assert.AreEqual(command.FirstName, user.FirstName);
                Assert.AreEqual(command.LastName, user.LastName);
                Assert.AreEqual(command.Email, user.Email);
                Assert.AreEqual(command.DisplayName, user.DisplayName);
                Assert.AreEqual(Common.HashPassword(command.Password), user.PasswordHash);
            }
        }
    }
}
