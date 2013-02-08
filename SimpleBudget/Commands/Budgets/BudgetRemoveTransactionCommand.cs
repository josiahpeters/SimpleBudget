using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/transaction/remove")]
	public class BudgetRemoveTransactionCommand
	{
		public BudgetRemoveTransactionCommand ()
		{
		}
	}
}

