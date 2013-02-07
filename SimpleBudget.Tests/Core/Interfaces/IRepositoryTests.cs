using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleBudget.Interfaces;

namespace SimpleBudget.Tests.Core.Interfaces
{
    [TestClass]
    public class IRepositoryTests : TestBase
    {
        User user;
        Budget budget;
        Category category;
        Transaction transaction;
        Bill bill;

        protected override void Initialize()
        {

            user = new User { Id = Guid.NewGuid(), FirstName = "Test", LastName = "User", Email = "testuser@test.com", DisplayName = "Sir. Test User" };
            budget = new Budget { Id = Guid.NewGuid(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(12), Frequency = Frequency.Monthly };
            category = new Category { Id = Guid.NewGuid(), Name = "Bills", Frequency = budget.Frequency };
            transaction = new Transaction { Id = Guid.NewGuid(), Description = "Test Transaction", Amount = 15.00m, Date = DateTime.Now, TransactionType = TransactionType.Outgoing };
            bill = new Bill { Id = Guid.NewGuid(), BillerName = "Test Biller", Nickname = "Test Bill Nickname", Frequency = Frequency.Monthly };
        }

        // User
        [TestMethod]
        public void CreateAndGetUser()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {

                context.Users.Create(user);
                var newUser = context.Users.Get(user.Id);

                Assert.AreEqual(user.Id, newUser.Id);
            }
        }
        [TestMethod]
        public void UpdateUser()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Users.Create(user);

                var changedUser = new User { Id = user.Id };

                context.Users.Update(changedUser);
                var updatedUser = context.Users.Get(user.Id);

                Assert.AreEqual(changedUser.Id, updatedUser.Id);
            }
        }
        [TestMethod]
        public void DeleteUser()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Users.Create(user);
                var newUser = context.Users.Get(user.Id);
                Assert.AreEqual(user.Id, newUser.Id);

                context.Users.Delete(user.Id);
                var deletedUser = context.Users.Get(user.Id);

                Assert.IsNull(deletedUser);
            }
        }

        // Budget
        [TestMethod]
        public void CreateAndGetBudget()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Budgets.Create(budget);
                var newBudget = context.Budgets.Get(budget.Id);

                Assert.AreEqual(budget.Id, newBudget.Id);
            }
        }
        [TestMethod]
        public void UpdateBudget()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Budgets.Create(budget);

                var changedBudget = new Budget { Id = budget.Id };

                context.Budgets.Update(changedBudget);
                var updatedBudget = context.Budgets.Get(budget.Id);

                Assert.AreEqual(changedBudget.Id, updatedBudget.Id);
            }
        }
        [TestMethod]
        public void DeleteBudget()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Budgets.Create(budget);
                var newBudget = context.Budgets.Get(budget.Id);
                Assert.AreEqual(budget.Id, newBudget.Id);

                context.Budgets.Delete(budget.Id);
                var deletedBudget = context.Budgets.Get(budget.Id);

                Assert.IsNull(deletedBudget);
            }
        }

        // Category
        [TestMethod]
        public void CreateAndGetCategory()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Categories.Create(category);
                var newCategory = context.Categories.Get(category.Id);

                Assert.AreEqual(category.Id, newCategory.Id);
            }
        }
        [TestMethod]
        public void UpdateCategory()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Categories.Create(category);

                var changedCategory = new Category { Id = category.Id };

                context.Categories.Update(changedCategory);
                var updatedCategory = context.Categories.Get(category.Id);

                Assert.AreEqual(changedCategory.Id, updatedCategory.Id);
            }
        }
        [TestMethod]
        public void DeleteCategory()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Categories.Create(category);
                var newCategory = context.Categories.Get(category.Id);
                Assert.AreEqual(category.Id, newCategory.Id);

                context.Categories.Delete(category.Id);
                var deletedCategory = context.Categories.Get(category.Id);

                Assert.IsNull(deletedCategory);
            }
        }

        // Transaction
        [TestMethod]
        public void CreateAndGetTransaction()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Transactions.Create(transaction);
                var newTransaction = context.Transactions.Get(transaction.Id);

                Assert.AreEqual(transaction.Id, newTransaction.Id);
            }
        }
        [TestMethod]
        public void UpdateTransaction()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Transactions.Create(transaction);

                var changedTransaction = new Transaction { Id = transaction.Id };

                context.Transactions.Update(changedTransaction);
                var updatedTransaction = context.Transactions.Get(transaction.Id);

                Assert.AreEqual(changedTransaction.Id, updatedTransaction.Id);
            }
        }
        [TestMethod]
        public void DeleteTransaction()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Transactions.Create(transaction);
                var newTransaction = context.Transactions.Get(transaction.Id);
                Assert.AreEqual(transaction.Id, newTransaction.Id);

                context.Transactions.Delete(transaction.Id);
                var deletedTransaction = context.Transactions.Get(transaction.Id);

                Assert.IsNull(deletedTransaction);
            }
        }

        // Bill
        [TestMethod]
        public void CreateAndGetBill()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Bills.Create(bill);
                var newBill = context.Bills.Get(bill.Id);

                Assert.AreEqual(bill.Id, newBill.Id);
            }
        }
        [TestMethod]
        public void UpdateBill()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Bills.Create(bill);

                var changedBill = new Bill { Id = bill.Id };

                context.Bills.Update(changedBill);
                var updatedBill = context.Bills.Get(bill.Id);

                Assert.AreEqual(changedBill.Id, updatedBill.Id);
            }
        }
        [TestMethod]
        public void DeleteBill()
        {
            using (var context = testSetup.Resolve<IRepositoryUnitOfWork>())
            {
                context.Bills.Create(bill);
                var newBill = context.Bills.Get(bill.Id);
                Assert.AreEqual(bill.Id, newBill.Id);

                context.Bills.Delete(bill.Id);
                var deletedBill = context.Bills.Get(bill.Id);

                Assert.IsNull(deletedBill);
            }
        }
    }
}
