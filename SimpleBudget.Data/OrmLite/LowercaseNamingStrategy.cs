using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.Data
{
    public class LowercaseNamingStrategy : OrmLiteNamingStrategyBase
    {
        public override string GetTableName(string name)
        {
            return name.ToLower();
        }

        public override string GetColumnName(string name)
        {
            return name.ToLower();
        }
    }
}
