using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/","POST")]
	public class BudgetCreateCommand
	{
		public BudgetCreateCommand ()
		{
		}
	}
}

