using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/transactions/{TransactionId}", "GET")]
	public class TransactionGetQuery
	{
        public Guid TransactionId { get; set; }

        public TransactionGetQuery()
		{
		}
	}
}

