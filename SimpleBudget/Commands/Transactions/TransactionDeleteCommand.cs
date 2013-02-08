using ServiceStack.ServiceHost;
using System;

namespace SimpleBudget
{
    [Route("/transactions/{TransactionId}/delete", "GET")]
    public class TransactionDeleteCommand
	{
        public Guid TransactionId { get; set; }

        public TransactionDeleteCommand()
		{
		}
	}
}

