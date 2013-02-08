using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/categories/{CategoryId}", "GET")]
	public class CategoryGetQuery
	{
        public Guid CategoryId { get; set; }

        public CategoryGetQuery()
		{
		}
	}
}

