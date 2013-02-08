using System;

namespace SimpleBudget
{
	public class TransactionResponse : Transaction
	{
		public TransactionResponse ()
		{
		}

        public TransactionResponse(Transaction transaction)
        {
            this.Id = transaction.Id;
            this.Amount = transaction.Amount;
            this.Description = transaction.Description;
            this.Date = transaction.Date;
            this.TransactionType = transaction.TransactionType;
        }
	}
}

