using ServiceStack.ServiceInterface;
using SimpleBudget.Commands;
using SimpleBudget.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.Services
{
    public class SimpleBudgetService : Service, ISimpleBudgetService
    {
        IRepositoryUnitOfWork repositoryUnitOfWork;

        public SimpleBudgetService(IRepositoryUnitOfWork repositoryUnitOfWork)
        {
            this.repositoryUnitOfWork = repositoryUnitOfWork;
        }
        [Authenticate]
        public object Post(UserCreateCommand command)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                DisplayName = command.DisplayName,
                PasswordHash = Common.HashPassword(command.Password)
            };

            repositoryUnitOfWork.Users.Create(user);

            return new CreateResponse { Id = user.Id };
            
        }
    }
}
