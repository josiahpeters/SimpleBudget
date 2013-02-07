using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.Interfaces
{
    public interface IBudgetRepository : IRepository<Budget>
    {
        // categories
        void AddCategoryToBudget(Guid categoryId, Guid budgetId);

        void RemoveCategoryFromBudget(Guid categoryId, Guid budgetId);

        List<Category> GetCategoriesByBudgetId(Guid Id);

        // transactions

        void AddTransactionToBudget(Guid transactionId, Guid budgetId);

        void RemoveTransactionFromBudget(Guid transactionId, Guid budgetId);

        List<Transaction> GetTransactionsByBudgetId(Guid Id);
    }
}
