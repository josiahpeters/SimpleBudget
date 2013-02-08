using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/transactions/add")]
	public class BudgetAddTransactionCommand
	{
		public BudgetAddTransactionCommand ()
		{
		}
	}
}

