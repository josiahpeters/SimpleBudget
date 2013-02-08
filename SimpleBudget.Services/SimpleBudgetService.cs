using ServiceStack.ServiceInterface;
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

        #region IUserService implementation

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

        public List<BudgetResponse> Get(UserGetBudgetsQuery query)
        {
            List<BudgetResponse> budgets = new List<BudgetResponse>();

            var budgetsInUser = repositoryUnitOfWork.Users.GetBudgetsByUserId((Guid)query.UserId);
            foreach (var budget in budgetsInUser)
                budgets.Add(new BudgetResponse(budget));

            return budgets;
        }

        #endregion

        #region IBudgetService implementation

        public CreateResponse Post(BudgetCreateCommand command)
        {
            var budget = new Budget
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                StartDate = command.StartDate,
                EndDate = command.EndDate,
                Frequency = command.Frequency
            };

            repositoryUnitOfWork.Budgets.Create(budget);

            return new CreateResponse { Id = budget.Id };
        }

        public bool Post(BudgetDeleteCommand command)
        {
            repositoryUnitOfWork.Budgets.Delete(command.BudgetId);

            return true;
        }

        public bool Post(BudgetAddCategoryCommand command)
        {
            repositoryUnitOfWork.Budgets.AddCategoryToBudget(command.CategoryId, command.BudgetId);

            return true;
        }

        public bool Post(BudgetAddTransactionCommand command)
        {
            repositoryUnitOfWork.Budgets.AddTransactionToBudget(command.TransactionId, command.BudgetId);

            return true;
        }

        public bool Post(BudgetRemoveCategoryCommand command)
        {
            repositoryUnitOfWork.Budgets.RemoveCategoryFromBudget(command.CategoryId, command.BudgetId);

            return true;
        }

        public bool Post(BudgetRemoveTransactionCommand command)
        {
            repositoryUnitOfWork.Budgets.RemoveTransactionFromBudget(command.TransactionId, command.BudgetId);

            return true;
        }

        public BudgetResponse Get(BudgetGetQuery query)
        {
            return new BudgetResponse(repositoryUnitOfWork.Budgets.Get(query.BudgetId));
        }

        public List<CategoryResponse> Get(BudgetGetCategoriesQuery query)
        {
            List<CategoryResponse> categories = new List<CategoryResponse>();

            var categoriesByBudget = repositoryUnitOfWork.Budgets.GetCategoriesByBudgetId(query.BudgetId);

            foreach (var category in categoriesByBudget)
                categories.Add(new CategoryResponse(category));

            return categories;
        }

        public List<TransactionResponse> Get(BudgetGetTransactionsQuery query)
        {
            List<TransactionResponse> transactions = new List<TransactionResponse>();

            var transactionsByBudget = repositoryUnitOfWork.Budgets.GetTransactionsByBudgetId(query.BudgetId);

            foreach (var transaction in transactionsByBudget)
                transactions.Add(new TransactionResponse(transaction));

            return transactions;
        }

        #endregion

        #region ICategoryService implementation

        public CreateResponse Post(CategoryCreateCommand command)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Frequency = command.Frequency
            };

            repositoryUnitOfWork.Categories.Create(category);

            // create budget to category relationship
            repositoryUnitOfWork.Budgets.AddCategoryToBudget(category.Id, command.BudgetId);

            return new CreateResponse { Id = category.Id };
        }

        public CategoryResponse Get(CategoryGetQuery query)
        {
            return new CategoryResponse(repositoryUnitOfWork.Categories.Get(query.CategoryId));
        }

        public bool Post(CategoryDeleteCommand command)
        {
            repositoryUnitOfWork.Categories.Delete(command.CategoryId);

            return true;
        }

        public bool Post(CategoryAddTransactionCommand command)
        {
            repositoryUnitOfWork.Categories.AddTransactionToCategory(command.TransactionId, command.CategoryId);

            return true;
        }

        public bool Post(CategoryRemoveTransactionCommand command)
        {
            repositoryUnitOfWork.Categories.RemoveTransactionFromCategory(command.TransactionId, command.CategoryId);

            return true;
        }        

        public List<TransactionResponse> Get(CategoryGetTransactionsQuery query)
        {
            List<TransactionResponse> transactions = new List<TransactionResponse>();

            var transactionsByCategory = repositoryUnitOfWork.Categories.GetTransactionsByCategoryId(query.CategoryId);

            foreach (var transaction in transactionsByCategory)
                transactions.Add(new TransactionResponse(transaction));

            return transactions;
        }

        #endregion

        #region ITransactionService implementation

        public CreateResponse Post(TransactionCreateCommand command)
        {
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                Amount = command.Amount,
                Description = command.Description,
                Date = command.Date,
                TransactionType = command.TransactionType,
            };

            repositoryUnitOfWork.Transactions.Create(transaction);

            // create budget to transaction relationship
            repositoryUnitOfWork.Budgets.AddTransactionToBudget(transaction.Id, command.BudgetId);

            // create category to transaction relationship
            repositoryUnitOfWork.Categories.AddTransactionToCategory(transaction.Id, command.CategoryId);

            return new CreateResponse { Id = transaction.Id };
        }

        public TransactionResponse Get(TransactionGetQuery query)
        {
            return new TransactionResponse(repositoryUnitOfWork.Transactions.Get(query.TransactionId));
        }

        public bool Post(TransactionDeleteCommand command)
        {
            repositoryUnitOfWork.Transactions.Delete(command.TransactionId);

            return true;
        }        

        #endregion
    }
}
