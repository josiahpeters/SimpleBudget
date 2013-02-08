using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/categories")]
	public class BudgetGetCategoriesQuery
	{
		public Guid Id { get; set; }
		
		public BudgetGetCategoriesQuery ()
		{
		}
	}
}

