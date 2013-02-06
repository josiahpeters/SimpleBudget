using System;
using SimpleBudget;
using SimpleBudget.Interfaces;
using ServiceStack.OrmLite;
using System.Data;


namespace SimpleBudget.Data
{
    public class BudgetRepository : OrmLiteRepository, IBudgetRepository
	{
        public BudgetRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

		#region IRepository implementation

		public void Create (Budget entity)
		{
            db.Insert<Budget>(entity);
		}

		public void Update (Budget entity)
		{
            db.Update(entity);
		}

		public void Delete (Guid Id)
		{
            db.Delete<Budget>(p => p.Id == Id);
		}

		public Budget Get (Guid Id)
		{
            return db.GetByIdOrDefault<Budget>(Id);
		}

		#endregion

        #region IBudgetRepository implementation

        public System.Collections.Generic.List<Category> GetCategoriesByBudgetId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public System.Collections.Generic.List<Transaction> GetTransactionsByBudgetId(Guid Id)
        {
            throw new NotImplementedException();
        }

		#endregion
    }
}

