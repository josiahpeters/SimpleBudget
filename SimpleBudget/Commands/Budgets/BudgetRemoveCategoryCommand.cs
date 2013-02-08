using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/categories/remove")]
	public class BudgetRemoveCategoryCommand
	{
		public BudgetRemoveCategoryCommand ()
		{
		}
	}
}

