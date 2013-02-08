using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/{BudgetId}", "GET")]
	public class BudgetGetQuery
	{
        public Guid BudgetId { get; set; }

		public BudgetGetQuery ()
		{
		}
	}
}

