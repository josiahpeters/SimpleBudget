using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/transactions/", "POST")]
	public class TransactionCreateCommand : Transaction
	{
        public Guid BudgetId { get; set; }

        public Guid CategoryId { get; set; }

        public TransactionCreateCommand()
		{
		}
	}
}

