using System;

namespace SimpleBudget
{
	public class BudgetResponse : Budget
	{
		public BudgetResponse ()
		{
		}

        public BudgetResponse(Budget budget)
        {
            this.Id = budget.Id;
            this.Name = budget.Name;
            this.StartDate = budget.StartDate;
            this.EndDate = budget.EndDate;
            this.Frequency = budget.Frequency;
        }
	}
}

