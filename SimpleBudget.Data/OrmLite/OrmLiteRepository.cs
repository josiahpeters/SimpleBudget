using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SimpleBudget.Data
{
    public class OrmLiteRepository
    {
        IDbConnection connection;
        protected IDbConnection db { get { return connection ?? (connection = connectionFactory.Open()); } }

        IDbConnectionFactory connectionFactory;

        public OrmLiteRepository(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }
    }
}
