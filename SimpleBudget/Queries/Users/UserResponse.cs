using System;

namespace SimpleBudget
{
    public class UserResponse : User
	{
        public UserResponse()
		{
		}

        public UserResponse(User user)
        {
            this.Id = user.Id;
            this.DisplayName = user.DisplayName;
            this.Email = user.Email;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
        }
	}
}

