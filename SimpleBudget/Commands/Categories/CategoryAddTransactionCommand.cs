using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/categories/{CategoryId}/transactions/add", "POST")]
    public class CategoryAddTransactionCommand
    {
        public Guid CategoryId { get; set; }

        public Guid TransactionId { get; set; }

        public CategoryAddTransactionCommand()
        {
        }
    }
}

