using System;
using SimpleBudget;
using SimpleBudget.Interfaces;
using ServiceStack.OrmLite;
using System.Data;


namespace SimpleBudget.Data
{
    public class BillRepository : OrmLiteRepository, IBillRepository
	{
        public BillRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

		#region IRepository implementation

		public void Create (Bill entity)
		{
            db.Insert<Bill>(entity);
		}

		public void Update (Bill entity)
		{
            db.Update(entity);
		}

		public void Delete (Guid Id)
		{
            db.Delete<Bill>(p => p.Id == Id);
		}

		public Bill Get (Guid Id)
		{
            return db.GetByIdOrDefault<Bill>(Id);
		}

		#endregion
	}
}

