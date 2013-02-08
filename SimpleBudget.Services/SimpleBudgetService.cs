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
		public CreateResponse Post(UserCreateCommand command)
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

		#region IBudgetService implementation

		public CreateResponse Post (BudgetCreateCommand command)
		{
			throw new NotImplementedException ();
		}

		public bool Post (BudgetDeleteCommand command)
		{
			throw new NotImplementedException ();
		}

		public bool Post (BudgetAddCategoryCommand command)
		{
			throw new NotImplementedException ();
		}

		public bool Post (BudgetAddTransactionCommand command)
		{
			throw new NotImplementedException ();
		}

		public bool Post (BudgetRemoveCategoryCommand command)
		{
			throw new NotImplementedException ();
		}

		public bool Post (BudgetRemoveTransactionCommand command)
		{
			throw new NotImplementedException ();
		}

		public List<BudgetResponse> Get (BudgetGetQuery query)
		{
			throw new NotImplementedException ();
		}

		public List<CategoryResponse> Get (BudgetGetCategoriesQuery query)
		{
			throw new NotImplementedException ();
		}

		public List<TransactionResponse> Get (BudgetGetTransactionsQuery query)
		{
			throw new NotImplementedException ();
		}

		#endregion
    }
}
