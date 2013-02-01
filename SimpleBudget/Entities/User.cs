using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBudget
{
    public class User : IIdentifiable
    {
        public Guid Id { get; set; }
    }
}
