using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/categories/{CategoryId}/transactions/remove", "POST")]
	public class CategoryRemoveTransactionCommand
    {
        public Guid CategoryId { get; set; }

        public Guid TransactionId { get; set; }

        public CategoryRemoveTransactionCommand()
		{
		}
	}
}

