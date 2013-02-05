using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        bool AuthenticateUser(string username, string password);

        void AddBudgetToUser(Guid budgetId, Guid userId);

        void RemoveBudgetFromUser(Guid budgetId, Guid userId);

        List<Budget> GetBudgetsByUserId(Guid Id);
    }
}
