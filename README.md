SimpleBudget
============

REST endpoint structure

Auth
    [Route("/auth/{provider}", "POST")]

Users
    [Route("/users/", "POST")]
    [Route("/users/{UserId}/budgets/", "GET")]

Budgets
    [Route("/budgets/","POST")]
    [Route("/budgets/{BudgetId}", "GET")]	 
    [Route("/budgets/{BudgetId}/delete")]
	 
    [Route("/budgets/{BudgetId}/categories", "GET")]
    [Route("/budgets/{BudgetId}/categories/add", "POST")]	 
    [Route("/budgets/{BudgetId}/categories/remove", "POST")]
	 
    [Route("/budgets/{BudgetId}/transactions", "GET")]
    [Route("/budgets/{BudgetId}/transactions/add", "POST")]
    [Route("/budgets/{BudgetId}/transactions/remove", "POST")]

Categories
    [Route("/categories/","POST")]
    [Route("/categories/{CategoryId}", "GET")]
    [Route("/categories/{CategoryId}/delete", "GET")]

    [Route("/categories/{CategoryId}/transactions", "GET")]
    [Route("/categories/{CategoryId}/transactions/add", "POST")]
    [Route("/categories/{CategoryId}/transactions/remove", "POST")]

Transactions
    [Route("/transactions/","POST")]
    [Route("/transactions/{TransactionId}", "GET")]
    [Route("/transactions/{TransactionId}/delete", "GET")]

App Structure
    
	User
		Properties
			DisplayName
			EmailAddress
			Preferences

        Command
			CreateUser

        Query
			GetAuthenticatedUser

	Budget
		Properties
			Name
			StartDate
			EndDate
			Frequency

        Command
			CreateBudget
			ChangeBudget

        Query
			GetBudgets
			GetBills
			GetCategories
			GetTransactions

    Bill
		Properties
			BillerName
			Nickname
			Frequency

        Command
			CreateBill
			ChangeBill
			PayBill

        Query
			GetBill

    

    Category
		Properties
			Name
			Frequency
			Amount

        Command
			CreateCategory
			ChangeBudget
			AddTransactionToCategory

        Query
			GetCategory

    Transaction
		Properties			
			Date
			Description
			Amount

		Relationships
			

        Command
			CreateTransaction

        Query
