using SimpleBudget.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget
{
    public interface IRepositoryUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        IBudgetRepository Budgets { get; }

        ICategoryRepository Categories { get; }

        ITransactionRepository Transactions { get; }

        IBillRepository Bills { get; }
    }
}
