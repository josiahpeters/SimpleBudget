using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/categories/","POST")]
    public class CategoryCreateCommand : Category
	{
        public Guid BudgetId { get; set; }

        public CategoryCreateCommand()
		{
		}
	}
}

