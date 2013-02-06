using System;
using SimpleBudget;
using SimpleBudget.Interfaces;
using ServiceStack.OrmLite;
using System.Data;
using System.Collections.Generic;


namespace SimpleBudget.Data
{
    public class CategoryRepository : OrmLiteRepository, ICategoryRepository
	{
        public CategoryRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

		#region IRepository implementation

		public void Create (Category entity)
		{
            db.Insert<Category>(entity);
		}

		public void Update (Category entity)
		{
            db.Update(entity);
		}

		public void Delete (Guid Id)
		{
            db.Delete<Category>(p => p.Id == Id);
		}

		public Category Get (Guid Id)
		{
            return db.GetByIdOrDefault<Category>(Id);
		}

		#endregion

        #region IBudgetRepository implementation

        public List<Transaction> GetTransactionsByCategoryId(Guid Id)
        {
            throw new NotImplementedException();
        }

		#endregion
    }
}

