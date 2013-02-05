using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;

namespace SimpleBudget
{
    public class UserToBudget
    {
        [ForeignKey(typeof(Budget), OnDelete = "NO ACTION")]
        public Guid BudgetId { get; set; }

        [ForeignKey(typeof(User), OnDelete = "NO ACTION")]
        public Guid UserId { get; set; }
    }

    public class UserToTransaction
    {
        [ForeignKey(typeof(Transaction))]
        public Guid TransactionId { get; set; }

        [ForeignKey(typeof(User))]
        public Guid UserId { get; set; }
    }

    public class BudgetToCategory
    {
        [ForeignKey(typeof(Category))]
        public Guid CategoryId { get; set; }

        [ForeignKey(typeof(Budget))]
        public Guid BudgetId { get; set; }

    }

    public class BudgetToTransaction
    {
        [ForeignKey(typeof(Transaction))]
        public Guid TransactionId { get; set; }

        [ForeignKey(typeof(Budget))]
        public Guid BudgetId { get; set; }

    }

    public class CategoryToTransaction
    {
        [ForeignKey(typeof(Transaction))]
        public Guid TransactionId { get; set; }

        [ForeignKey(typeof(Category))]
        public Guid CategoryId { get; set; }
    }
}
