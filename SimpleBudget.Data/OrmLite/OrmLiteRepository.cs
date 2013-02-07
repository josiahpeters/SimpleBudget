using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SimpleBudget.Data
{
    public class OrmLiteRepository : IDisposable
    {
        protected IDbConnection db;

        public OrmLiteRepository(IDbConnection connection)
        {
            this.db = connection;
        }

        public void Dispose()
        {
            //if (db != null && db.State != ConnectionState.Closed)
            //{
            //    db.Close();
            //}
        }
    }
}
