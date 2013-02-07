using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        // transactions

        void AddTransactionToCategory(Guid transactionId, Guid categoryId);

        void RemoveTransactionFromCategory(Guid transactionId, Guid categoryId);

        List<Transaction> GetTransactionsByCategoryId(Guid Id);
    }
}
