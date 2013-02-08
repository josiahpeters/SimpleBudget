using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.Services
{
    public interface ISimpleBudgetService : IService, IUserService, IBudgetService, ICategoryService, ITransactionService
    {

    }
}
