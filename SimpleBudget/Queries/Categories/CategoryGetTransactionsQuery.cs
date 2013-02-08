using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/categories/{CategoryId}/transactions", "GET")]
	public class CategoryGetTransactionsQuery
	{
        public Guid CategoryId { get; set; }

        public CategoryGetTransactionsQuery()
		{
		}
	}
}

