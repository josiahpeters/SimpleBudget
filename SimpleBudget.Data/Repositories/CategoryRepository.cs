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
        public CategoryRepository(IDbConnection connection) : base(connection) { }

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

        #region ICategoryRepository implementation

        public void AddTransactionToCategory(Guid transactionId, Guid categoryId)
        {
            var relationship = new CategoryToTransaction { TransactionId = transactionId, CategoryId = categoryId };

            db.Insert(relationship);
        }

        public void RemoveTransactionFromCategory(Guid transactionId, Guid categoryId)
        {
            var relationship = new CategoryToTransaction { TransactionId = transactionId, CategoryId = categoryId };

            db.Delete(relationship);
        }

        public List<Transaction> GetTransactionsByCategoryId(Guid Id)
        {
            return db.Select<Transaction>("SELECT * FROM Transaction INNER JOIN CategoryToTransaction ON Transaction.Id = TransactionId WHERE CategoryId = {0}", Id);
        }

		#endregion

    }
}
