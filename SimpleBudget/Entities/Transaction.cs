using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget
{
    public class Transaction : IIdentifiable
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public TransactionType TransactionType { get; set; }

        public DateTime Date { get; set; }
    }
}
