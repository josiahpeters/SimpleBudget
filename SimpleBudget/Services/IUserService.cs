using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleBudget.Queries;

namespace SimpleBudget.Services
{
    public interface IUserService
    {
		CreateResponse Post(UserCreateCommand command);

        List<BudgetResponse> Get(UserGetBudgetsQuery query);
    }
}
