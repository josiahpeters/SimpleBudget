using System;
using SimpleBudget.Queries;
using System.Collections.Generic;

namespace SimpleBudget
{
    public interface ITransactionService
	{
		CreateResponse Post(TransactionCreateCommand command);

        TransactionResponse Get(TransactionGetQuery query);
		
		bool Post(TransactionDeleteCommand command);
	}
}