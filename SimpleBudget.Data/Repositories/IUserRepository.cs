using System;
using SimpleBudget;
using SimpleBudget.Interfaces;


namespace SimpleBudget.Data
{
	public class UserRepository : IUserRepository
	{
		#region IRepository implementation

		public void Create (User entity)
		{
			DB.Insert<User>(entity);
		}

		public void Update (User entity)
		{
			throw new NotImplementedException ();
		}

		public void Delete (Guid Id)
		{
			throw new NotImplementedException ();
		}

		public User Get (Guid Id)
		{
			return DB.Query<User>(u => u.Id == Id);
		}

		#endregion
		
		#region IUserRepository implementation
		public bool AuthenticateUser (string username, string password)
		{
			var user = DB.Query<User>(u => u.UserName == username && u.PasswordHash == Common.HashPassword(password));
			return user != null;
		}
		#endregion
	}
}

