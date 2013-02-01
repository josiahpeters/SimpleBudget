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

        //void Create(T entity);
        [TestMethod]
        public void CreateAndGet()
        {
            // User 
            userRepository.Create(user);
            var newUser = userRepository.Get(user.Id);

            Assert.AreEqual(user.Id, newUser.Id);

            // Budget


            // Category


            // Transaction


            // Bill

        }

        //void Update(T entity);
        [TestMethod]
        public void Update()
        {
            //T Get(Guid Id);
        }

        //void Delete(Guid Id);
        [TestMethod]
        public void Delete()
        {
        }
    }
}
