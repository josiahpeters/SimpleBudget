using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/{BudgetId}/categories", "GET")]
	public class BudgetGetCategoriesQuery
	{
		public Guid BudgetId { get; set; }
		
		public BudgetGetCategoriesQuery ()
		{
		}
	}
}

