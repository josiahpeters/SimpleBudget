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
        IDbConnection connection = null;
        protected IDbConnection db;
        //{
        //    get
        //    {
        //        if(connection == null)
        //            connection = connectionFactory.Open();
        //        return connection;
        //    }
        //}

        IDbConnectionFactory connectionFactory;

        public OrmLiteRepository(IDbConnection connection)
        {
            this.connection = connection;
            this.db = connection;
        }

        public void Dispose()
        {
            if (db != null && db.State != ConnectionState.Closed)
            {
                db.Close();
            }
        }
    }
}
