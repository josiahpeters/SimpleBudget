using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.Interfaces
{
    public interface IBudgetRepository : IRepository<Budget>
    {
        List<Category> GetCategoriesByBudgetId(Guid Id);
        List<Transaction> GetTransactionsByBudgetId(Guid Id);
    }
}
