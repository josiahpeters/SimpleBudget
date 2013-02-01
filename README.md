SimpleBudget
============

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
