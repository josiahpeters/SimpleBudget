using System;
using SimpleBudget.Queries;
using System.Collections.Generic;

namespace SimpleBudget
{
	public interface IBudgetService
	{
		CreateResponse Post(BudgetCreateCommand command);
		
		bool Post(BudgetDeleteCommand command);

		bool Post(BudgetAddCategoryCommand command);

		bool Post(BudgetAddTransactionCommand command);

		bool Post(BudgetRemoveCategoryCommand command);

		bool Post(BudgetRemoveTransactionCommand command);

		List<BudgetResponse> Get(BudgetGetQuery query);

		List<CategoryResponse> Get(BudgetGetCategoriesQuery query);

		List<TransactionResponse> Get(BudgetGetTransactionsQuery query);
	}
}