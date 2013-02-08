using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/{BudgetId}/categories/add", "POST")]
	public class BudgetAddCategoryCommand
	{
        public Guid BudgetId { get; set; }

        public Guid CategoryId { get; set; }

		public BudgetAddCategoryCommand ()
		{
		}
	}
}

