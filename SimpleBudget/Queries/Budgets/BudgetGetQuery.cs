using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/","GET")]
	public class BudgetGetQuery
	{
		public Guid? Id { get; set; }

		public BudgetGetQuery ()
		{
		}
	}
}

