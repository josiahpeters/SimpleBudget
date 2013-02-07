using System;
using SimpleBudget;
using SimpleBudget.Interfaces;
using ServiceStack.OrmLite;
using System.Data;
using System.Collections.Generic;


namespace SimpleBudget.Data
{
    public class BudgetRepository : OrmLiteRepository, IBudgetRepository
    {
        public BudgetRepository(IDbConnection connection) : base(connection) { }

        #region IRepository implementation

        public void Create(Budget entity)
        {
            db.Insert<Budget>(entity);
        }

        public void Update(Budget entity)
        {
            db.Update(entity);
        }

        public void Delete(Guid Id)
        {
            db.Delete<Budget>(p => p.Id == Id);
        }

        public Budget Get(Guid Id)
        {
            return db.GetByIdOrDefault<Budget>(Id);
        }

        #endregion

        #region IBudgetRepository implementation

        public void AddCategoryToBudget(Guid categoryId, Guid budgetId)
        {
            var relationship = new BudgetToCategory { CategoryId = categoryId, BudgetId = budgetId };

            db.Insert(relationship);
        }

        public void RemoveCategoryFromBudget(Guid categoryId, Guid budgetId)
        {
            var relationship = new BudgetToCategory { CategoryId = categoryId, BudgetId = budgetId };

            db.Delete(relationship);
        }

        public List<Category> GetCategoriesByBudgetId(Guid Id)
        {
            return db.Select<Category>("SELECT * FROM Category INNER JOIN BudgetToCategory ON Category.Id = CategoryId WHERE BudgetId = {0}", Id);
        }

        public void AddTransactionToBudget(Guid transactionId, Guid budgetId)
        {
            var relationship = new BudgetToTransaction { TransactionId = transactionId, BudgetId = budgetId };

            db.Insert(relationship);
        }

        public void RemoveTransactionFromBudget(Guid transactionId, Guid budgetId)
        {
            var relationship = new BudgetToTransaction { TransactionId = transactionId, BudgetId = budgetId };

            db.Delete(relationship);
        }

        public List<Transaction> GetTransactionsByBudgetId(Guid Id)
        {
            return db.Select<Transaction>("SELECT * FROM Transaction INNER JOIN BudgetToTransaction ON Transaction.Id = TransactionId WHERE BudgetId = {0}", Id);
        }

        #endregion

    }
}

