using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/remove")]
	public class BudgetRemoveCommand
	{
		public BudgetRemoveCommand ()
		{
		}
	}
}

