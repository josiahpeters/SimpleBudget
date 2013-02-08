using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/{BudgetId}/transactions/remove", "POST")]
	public class BudgetRemoveTransactionCommand
    {
        public Guid BudgetId { get; set; }

        public Guid TransactionId { get; set; }

		public BudgetRemoveTransactionCommand ()
		{
		}
	}
}

