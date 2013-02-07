using SimpleBudget.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SimpleBudget.Data
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork, IDisposable
    {
        IUserRepository userRepository;
        IBudgetRepository budgetRepository;
        ICategoryRepository categoryRepository;
        ITransactionRepository transactionRepository;
        IBillRepository billRepository;

        IDbConnection connection;

        public RepositoryUnitOfWork(IUserRepository userRepository = null, IBudgetRepository budgetRepository = null, ICategoryRepository categoryRepository = null, ITransactionRepository transactionRepository = null, IBillRepository billRepository = null, IDbConnection connection = null)
        {
            this.userRepository = userRepository;
            this.budgetRepository = budgetRepository;
            this.categoryRepository = categoryRepository;
            this.transactionRepository = transactionRepository;
            this.billRepository = billRepository;
            this.connection = connection;
        }

        public IUserRepository Users
        {
            get
            {
                return userRepository;
            }
        }

        public IBudgetRepository Budgets
        {
            get
            {
                return budgetRepository;
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                return categoryRepository;
            }
        }

        public ITransactionRepository Transactions
        {
            get
            {
                return transactionRepository;
            }
        }

        public IBillRepository Bills
        {
            get
            {
                return billRepository;
            }
        }

        public void Dispose()
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}
