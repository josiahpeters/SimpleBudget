using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleBudget.Tests.Core.Interfaces
{
    [TestClass]
    public class IRepositoryTests
    {
        AutofacTestSetup testSetup;

        IRepository<User> userRepository;
        IRepository<Budget> budgetRepository;
        IRepository<Category> categoryRepository;
        IRepository<Transaction> transactionRepository;
        IRepository<Bill> billRepository;

        User user;
        Budget budget;
        Category category;
        Transaction transaction;
        Bill bill;

        [TestInitialize]
        public void Init()
        {
            testSetup = new AutofacTestSetup();

            userRepository = testSetup.Resolve<IRepository<User>>();
            budgetRepository = testSetup.Resolve<IRepository<Budget>>();
            categoryRepository = testSetup.Resolve<IRepository<Category>>();
            transactionRepository = testSetup.Resolve<IRepository<Transaction>>();
            billRepository = testSetup.Resolve<IRepository<Bill>>();

            initializeTestData();
        }

        private void initializeTestData()
        {
            user = new User { Id = Guid.NewGuid() };
            budget = new Budget { Id = Guid.NewGuid(), StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(12), Frequency = Frequency.Monthly };
            category = new Category { Id = Guid.NewGuid(), Name = "Bills", Frequency = budget.Frequency };
            transaction = new Transaction { Id = Guid.NewGuid(), Description = "Test Transaction", Amount = 15.00m, Date = DateTime.Now, TransactionType = TransactionType.Outgoing };
            bill = new Bill { Id = Guid.NewGuid(), BillerName = "Test Biller", Nickname = "Test Bill Nickname", Frequency = Frequency.Monthly };
        }

        // User
        [TestMethod]
        public void CreateAndGetUser()
        {
            userRepository.Create(user);
            var newUser = userRepository.Get(user.Id);

            Assert.AreEqual(user.Id, newUser.Id);
        }
        [TestMethod]
        public void UpdateUser()
        {
            userRepository.Create(user);

            var changedUser = new User { Id = user.Id };

            userRepository.Update(changedUser);
            var updatedUser = userRepository.Get(user.Id);

            Assert.AreEqual(changedUser.Id, updatedUser.Id);
        }
        [TestMethod]
        public void DeleteUser()
        {
            userRepository.Create(user);
            var newUser = userRepository.Get(user.Id);
            Assert.AreEqual(user.Id, newUser.Id);

            userRepository.Delete(user.Id);
            var deletedUser = userRepository.Get(user.Id);

            Assert.IsNull(deletedUser);
        }

        // Budget
        [TestMethod]
        public void CreateAndGetBudget()
        {
            budgetRepository.Create(budget);
            var newBudget = budgetRepository.Get(budget.Id);

            Assert.AreEqual(budget.Id, newBudget.Id);
        }
        [TestMethod]
        public void UpdateBudget()
        {
            budgetRepository.Create(budget);

            var changedBudget = new Budget { Id = budget.Id };

            budgetRepository.Update(changedBudget);
            var updatedBudget = budgetRepository.Get(budget.Id);

            Assert.AreEqual(changedBudget.Id, updatedBudget.Id);
        }
        [TestMethod]
        public void DeleteBudget()
        {
            budgetRepository.Create(budget);
            var newBudget = budgetRepository.Get(budget.Id);
            Assert.AreEqual(budget.Id, newBudget.Id);

            budgetRepository.Delete(budget.Id);
            var deletedBudget = budgetRepository.Get(budget.Id);

            Assert.IsNull(deletedBudget);
        }

        // Category
        [TestMethod]
        public void CreateAndGetCategory()
        {
            categoryRepository.Create(category);
            var newCategory = categoryRepository.Get(category.Id);

            Assert.AreEqual(category.Id, newCategory.Id);
        }
        [TestMethod]
        public void UpdateCategory()
        {
            categoryRepository.Create(category);

            var changedCategory = new Category { Id = category.Id };

            categoryRepository.Update(changedCategory);
            var updatedCategory = categoryRepository.Get(category.Id);

            Assert.AreEqual(changedCategory.Id, updatedCategory.Id);
        }
        [TestMethod]
        public void DeleteCategory()
        {
            categoryRepository.Create(category);
            var newCategory = categoryRepository.Get(category.Id);
            Assert.AreEqual(category.Id, newCategory.Id);

            categoryRepository.Delete(category.Id);
            var deletedCategory = categoryRepository.Get(category.Id);

            Assert.IsNull(deletedCategory);
        }       

        // Transaction
        [TestMethod]
        public void CreateAndGetTransaction()
        {
            transactionRepository.Create(transaction);
            var newTransaction = transactionRepository.Get(transaction.Id);

            Assert.AreEqual(transaction.Id, newTransaction.Id);
        }
        [TestMethod]
        public void UpdateTransaction()
        {
            transactionRepository.Create(transaction);

            var changedTransaction = new Transaction { Id = transaction.Id };

            transactionRepository.Update(changedTransaction);
            var updatedTransaction = transactionRepository.Get(transaction.Id);

            Assert.AreEqual(changedTransaction.Id, updatedTransaction.Id);
        }
        [TestMethod]
        public void DeleteTransaction()
        {
            transactionRepository.Create(transaction);
            var newTransaction = transactionRepository.Get(transaction.Id);
            Assert.AreEqual(transaction.Id, newTransaction.Id);

            transactionRepository.Delete(transaction.Id);
            var deletedTransaction = transactionRepository.Get(transaction.Id);

            Assert.IsNull(deletedTransaction);
        }

        // Bill
        [TestMethod]
        public void CreateAndGetBill()
        {
            billRepository.Create(bill);
            var newBill = billRepository.Get(bill.Id);

            Assert.AreEqual(bill.Id, newBill.Id);
        }
        [TestMethod]
        public void UpdateBill()
        {
            billRepository.Create(bill);

            var changedBill = new Bill { Id = bill.Id };

            billRepository.Update(changedBill);
            var updatedBill = billRepository.Get(bill.Id);

            Assert.AreEqual(changedBill.Id, updatedBill.Id);
        }
        [TestMethod]
        public void DeleteBill()
        {
            billRepository.Create(bill);
            var newBill = billRepository.Get(bill.Id);
            Assert.AreEqual(bill.Id, newBill.Id);

            billRepository.Delete(bill.Id);
            var deletedBill = billRepository.Get(bill.Id);

            Assert.IsNull(deletedBill);
        }
    }
}
