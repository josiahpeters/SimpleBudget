using ServiceStack.ServiceHost;
using System;

namespace SimpleBudget
{
    [Route("/budgets/{BudgetId}/delete")]
    public class BudgetDeleteCommand
	{
        public Guid BudgetId { get; set; }

		public BudgetDeleteCommand ()
		{
		}
	}
}

