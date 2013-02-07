using SimpleBudget.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.Services
{
    public interface IUserService
    {
        object Post(UserCreateCommand command);
    }
}
