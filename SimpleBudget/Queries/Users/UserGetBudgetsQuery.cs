using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget
{
    [Route("/users/{UserId}/budgets/", "GET")]
    public class UserGetBudgetsQuery
    {
        public Guid UserId { get; set; }

        public UserGetBudgetsQuery()
        {
        }
    }
}
