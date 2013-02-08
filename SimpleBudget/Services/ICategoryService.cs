using System;
using SimpleBudget.Queries;
using System.Collections.Generic;

namespace SimpleBudget
{
    public interface ICategoryService
	{
		CreateResponse Post(CategoryCreateCommand command);

        CategoryResponse Get(CategoryGetQuery query);
		
		bool Post(CategoryDeleteCommand command);

		bool Post(CategoryAddTransactionCommand command);

		bool Post(CategoryRemoveTransactionCommand command);

		List<TransactionResponse> Get(CategoryGetTransactionsQuery query);
	}
}