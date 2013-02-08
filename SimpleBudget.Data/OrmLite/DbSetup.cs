using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ServiceStack.OrmLite;

namespace SimpleBudget.Data.OrmLite
{
    public class DbSetup
    {
        public static void Setup(IDbConnection db)
        {
            var drop = false;

            //drop = true;
            
            if (drop)
            {
                //string databaseName = db.Database;
                //db.ChangeDatabase("postgres");
                //db.ExecuteSql(String.Format("DROP DATABASE {0}", databaseName));
                //db.ExecuteSql(String.Format("CREATE DATABASE {0}", databaseName));
                //db.ChangeDatabase(databaseName);

                db.DropTable<CategoryToTransaction>();

                db.DropTable<BudgetToTransaction>();
                db.DropTable<BudgetToCategory>();

                db.DropTable<UserToTransaction>();
                db.DropTable<UserToBudget>();

                db.DropTable<Transaction>();
                db.DropTable<Bill>();
                db.DropTable<Category>();
                db.DropTable<Budget>();
                db.DropTable<User>();

                db.CreateTables
                (
                     true,
                     typeof(User),
                     typeof(Budget),
                     typeof(Category),
                     typeof(Bill),
                     typeof(Transaction),

                     typeof(UserToBudget),
                     typeof(UserToTransaction),

                     typeof(BudgetToCategory),
                     typeof(BudgetToTransaction),

                     typeof(CategoryToTransaction)
                );
            }
        }
    }
}
