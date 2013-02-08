using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/transactions")]
	public class BudgetGetTransactionsQuery
	{
		public Guid Id { get; set; }
		
		public BudgetGetTransactionsQuery ()
		{
		}
	}
}

