using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/{BudgetId}/categories/remove", "POST")]
	public class BudgetRemoveCategoryCommand
    {
        public Guid BudgetId { get; set; }

        public Guid CategoryId { get; set; }

		public BudgetRemoveCategoryCommand ()
		{
		}
	}
}

