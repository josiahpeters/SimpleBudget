using System;
using SimpleBudget;
using SimpleBudget.Interfaces;
using ServiceStack.OrmLite;
using System.Data;


namespace SimpleBudget.Data
{
    public class TransactionRepository : OrmLiteRepository, ITransactionRepository
	{
        public TransactionRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

		#region IRepository implementation

		public void Create (Transaction entity)
		{
            db.Insert<Transaction>(entity);
		}

		public void Update (Transaction entity)
		{
            db.Update(entity);
		}

		public void Delete (Guid Id)
		{
            db.Delete<Transaction>(p => p.Id == Id);
		}

		public Transaction Get (Guid Id)
		{
            return db.GetById<Transaction>(Id);
		}

		#endregion
		
	}
}

