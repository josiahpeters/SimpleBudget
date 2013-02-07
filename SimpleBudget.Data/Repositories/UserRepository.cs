using System;
using SimpleBudget;
using SimpleBudget.Interfaces;
using ServiceStack.OrmLite;
using System.Data;
using System.Collections.Generic;


namespace SimpleBudget.Data
{
    public class UserRepository : OrmLiteRepository, IUserRepository
    {        
        public UserRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

        #region IRepository implementation

        public void Create(User entity)
        {
            db.Insert<User>(entity);
        }

        public void Update(User entity)
        {
            db.Update(entity);
        }

        public void Delete(Guid Id)
        {
            db.Delete<User>(p => p.Id == Id);
        }

        public User Get(Guid Id)
        {
            return db.GetByIdOrDefault<User>(Id);
        }

        #endregion

        #region IUserRepository implementation

        public bool AuthenticateUser(string username, string password)
        {
            var user = db.Select<User>(q => q.Email == username && q.PasswordHash == Common.HashPassword(password));
            return user != null;
        }

        public void AddBudgetToUser(Guid budgetId, Guid userId)
        {
            var relationship = new UserToBudget { UserId = userId, BudgetId = budgetId };

            db.Insert(relationship);
        }

        public void RemoveBudgetFromUser(Guid budgetId, Guid userId)
        {
            var relationship = new UserToBudget { UserId = userId, BudgetId = budgetId };

            db.Delete(relationship);
        }

        public List<Budget> GetBudgetsByUserId(Guid Id)
        {
            return db.Select<Budget>("SELECT * FROM Budget INNER JOIN UserToBudget ON Budget.Id = BudgetId WHERE UserId = {0}", Id);
        }

        #endregion

    }
}

