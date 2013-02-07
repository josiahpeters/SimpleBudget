using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget.Queries
{
    public class CreateResponse : IIdentifiable
    {
        public Guid Id { get; set; }
    }
}
