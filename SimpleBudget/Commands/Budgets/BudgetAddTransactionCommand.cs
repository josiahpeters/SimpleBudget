using System;
using ServiceStack.ServiceHost;

namespace SimpleBudget
{
    [Route("/budgets/{BudgetId}/transactions/add", "POST")]
    public class BudgetAddTransactionCommand
    {
        public Guid BudgetId { get; set; }

        public Guid TransactionId { get; set; }

        public BudgetAddTransactionCommand()
        {
        }
    }
}

