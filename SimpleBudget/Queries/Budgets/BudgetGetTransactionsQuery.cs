using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/{BudgetId}/transactions", "GET")]
	public class BudgetGetTransactionsQuery
	{
        public Guid BudgetId { get; set; }
		
		public BudgetGetTransactionsQuery ()
		{
		}
	}
}

